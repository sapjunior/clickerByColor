using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
namespace clickerByColor
{
    public partial class selectColorForm : Form
    {
        private Mat originalCurrentVideoFrame, dispCurrentVideoFrame;
        public  RangeF hueRange;
        private Point clickStartPoint;
        private Rectangle roiRect = new Rectangle();
        public selectColorForm(Mat currentVideoFrame,ref RangeF _hueRange)
        {
            InitializeComponent();
            currentVideoFrame = keepAspectRatioResize(currentVideoFrame, new Size(fromWebcamPictureBox.Width,fromWebcamPictureBox.Height));
            originalCurrentVideoFrame = currentVideoFrame;
            dispCurrentVideoFrame = currentVideoFrame;
            hueRange = _hueRange;
        }

        private void fromWebcamPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            clickStartPoint = e.Location;
            Invalidate();
        }

        private void fromWebcamPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            dispCurrentVideoFrame = originalCurrentVideoFrame.Clone();
            int X0, Y0;
            ConvertCoordinates(fromWebcamPictureBox, out X0, out Y0, e.X, e.Y);
            //Coordinates at input picture box
            if (e.Button != MouseButtons.Left)
                return;
            Point tempEndPoint = e.Location;
            roiRect.Location = new Point(
                Math.Min(clickStartPoint.X, tempEndPoint.X),
                Math.Min(clickStartPoint.Y, tempEndPoint.Y));
            roiRect.Size = new Size(
                Math.Abs(clickStartPoint.X - tempEndPoint.X),
                Math.Abs(clickStartPoint.Y - tempEndPoint.Y));

            CvInvoke.Rectangle(dispCurrentVideoFrame, roiRect, new MCvScalar(0, 0, 255), 2);
            applySegmentation();
            fromWebcamPictureBox.Image = dispCurrentVideoFrame.Bitmap;


            ((PictureBox)sender).Invalidate();
        }
        private void applySegmentation()
        {
            Mat segmentationResultMat = new Mat();
            Mat hsvImage = new Mat();
            Mat blurOriginalCurrentVideoFrame = new Mat();
            CvInvoke.MedianBlur(originalCurrentVideoFrame, blurOriginalCurrentVideoFrame, 5);
            //CvInvoke.Blur(originalCurrentVideoFrame, blurOriginalCurrentVideoFrame, new Size(3, 3),new Point(-1,-1));

            CvInvoke.CvtColor(originalCurrentVideoFrame, hsvImage, ColorConversion.Bgr2Hsv);
            Mat[] hsvImageChannels = hsvImage.Split();

            // Extract Hue
            Mat hueImageRoi = new Mat(hsvImageChannels[0], roiRect);
            RangeF currentHueRange = hueImageRoi.GetValueRange();
            CvInvoke.InRange(hsvImageChannels[0],new ScalarArray(hueRange.Min),new ScalarArray(hueRange.Max),segmentationResultMat);

            segmentationResultPictureBox.Image = segmentationResultMat.Bitmap;

            hueRange = currentHueRange;
        }
        private void selectColorForm_Load(object sender, EventArgs e)
        {
            fromWebcamPictureBox.Image = dispCurrentVideoFrame.Bitmap;
        }

        private void selectColorForm_Resize(object sender, EventArgs e)
        {
            if (fromWebcamPictureBox.Image != null)
            {
                Image tempCopy = (Image)fromWebcamPictureBox.Image.Clone();
                Mat currentDispMat = GetMatFromSDImage(tempCopy);
                currentDispMat = keepAspectRatioResize(currentDispMat, new Size(fromWebcamPictureBox.Width, fromWebcamPictureBox.Height));
                fromWebcamPictureBox.Image = currentDispMat.Bitmap;
            }
        }

        private Mat keepAspectRatioResize(Mat inputImage, Size targetSize, int padColor = 0)
        {
            Mat resizedOutputImage = new Mat();
            
            double h1 = targetSize.Width * (inputImage.Rows / (double)inputImage.Cols);
            double w2 = targetSize.Height * (inputImage.Cols / (double)inputImage.Rows);
            if (h1 <= targetSize.Height)
            {
                CvInvoke.Resize(inputImage, resizedOutputImage, new Size(targetSize.Width, (int)h1), 0, 0, Inter.Lanczos4);
            }
            else
            {
                CvInvoke.Resize(inputImage, resizedOutputImage, new Size((int)w2, targetSize.Height), 0, 0, Inter.Lanczos4);
            }

            int top = (targetSize.Height - resizedOutputImage.Rows) / 2;
            int down = (targetSize.Height - resizedOutputImage.Rows + 1) / 2;
            int left = (targetSize.Width - resizedOutputImage.Cols) / 2;
            int right = (targetSize.Width - resizedOutputImage.Cols + 1) / 2;

            CvInvoke.CopyMakeBorder(resizedOutputImage, resizedOutputImage, top, down, left, right, BorderType.Constant, new MCvScalar(padColor, padColor, padColor));

            return resizedOutputImage;

        }
        private Mat GetMatFromSDImage(System.Drawing.Image image)
        {
            int stride = 0;
            Bitmap bmp = new Bitmap(image);

            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);

            System.Drawing.Imaging.PixelFormat pf = bmp.PixelFormat;
            if (pf == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            {
                stride = bmp.Width * 4;
            }
            else
            {
                stride = bmp.Width * 3;
            }

            Image<Bgra, byte> cvImage = new Image<Bgra, byte>(bmp.Width, bmp.Height, stride, (IntPtr)bmpData.Scan0);

            bmp.UnlockBits(bmpData);

            return cvImage.Mat;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {

        }


        public static void ConvertCoordinates(PictureBox pic,out int X0, out int Y0, int x, int y)
        {
            int pic_hgt = pic.ClientSize.Height;
            int pic_wid = pic.ClientSize.Width;
            int img_hgt = pic.Image.Height;
            int img_wid = pic.Image.Width;

            X0 = x;
            Y0 = y;
            switch (pic.SizeMode)
            {
                case PictureBoxSizeMode.AutoSize:
                case PictureBoxSizeMode.Normal:
                    // These are okay. Leave them alone.
                    break;
                case PictureBoxSizeMode.CenterImage:
                    X0 = x - (pic_wid - img_wid) / 2;
                    Y0 = y - (pic_hgt - img_hgt) / 2;
                    break;
                case PictureBoxSizeMode.StretchImage:
                    X0 = (int)(img_wid * x / (float)pic_wid);
                    Y0 = (int)(img_hgt * y / (float)pic_hgt);
                    break;
                case PictureBoxSizeMode.Zoom:
                    float pic_aspect = pic_wid / (float)pic_hgt;
                    float img_aspect = img_wid / (float)img_wid;
                    if (pic_aspect > img_aspect)
                    {
                        // The PictureBox is wider/shorter than the image.
                        Y0 = (int)(img_hgt * y / (float)pic_hgt);

                        // The image fills the height of the PictureBox.
                        // Get its width.
                        float scaled_width = img_wid * pic_hgt / img_hgt;
                        float dx = (pic_wid - scaled_width) / 2;
                        X0 = (int)((x - dx) * img_hgt / (float)pic_hgt);
                    }
                    else
                    {
                        // The PictureBox is taller/thinner than the image.
                        X0 = (int)(img_wid * x / (float)pic_wid);

                        // The image fills the height of the PictureBox.
                        // Get its height.
                        float scaled_height = img_hgt * pic_wid / img_wid;
                        float dy = (pic_hgt - scaled_height) / 2;
                        Y0 = (int)((y - dy) * img_wid / pic_wid);
                    }
                    break;
            }
        }
    }
}
