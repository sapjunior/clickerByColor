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
using Emgu.CV.Util;

namespace clickerByColor
{
    public partial class defineArea : Form
    {
        private Mat inputImage,dispImage;
        public Mat segmentedArea = new Mat();
        private Point oriCord;
        private List<PointF> fourCornerPoints = new List<PointF>();
        public defineArea(Mat _inputImage)
        {
            InitializeComponent();
            inputImage = _inputImage;
            oriCord = new Point(_inputImage.Height, _inputImage.Width);
            inputImage = _inputImage.Clone();
            //inputImage = keepAspectRatioResize(_inputImage, new Size(inputImagePictureBox.Width, inputImagePictureBox.Height));
            dispImage = inputImage.Clone();
            inputImagePictureBox.Image = dispImage.Bitmap;

        }

        PointF[] sortPoints(PointF[] unsorted)
        {
            PointF[] sorted = new PointF[4];
            for (int i = 0; i < 4; i++)
                sorted[0]= new PointF(0, 0);

            float middleX = (unsorted[0].X + unsorted[1].Y + unsorted[2].X + unsorted[3].Y) / 4.0f;
            float middleY = (unsorted[0].X + unsorted[1].Y + unsorted[2].Y + unsorted[3].Y) / 4.0f;
            for (int i = 0; i < 4; i++)
            {
                if (unsorted[i].X < middleX && unsorted[i].Y < middleY) sorted[0] = unsorted[i];
                if (unsorted[i].X > middleX && unsorted[i].Y < middleY) sorted[1] = unsorted[i];
                if (unsorted[i].X < middleX && unsorted[i].Y > middleY) sorted[2] = unsorted[i];
                if (unsorted[i].X > middleX && unsorted[i].Y > middleY) sorted[3] = unsorted[i];
            }
            return sorted;
        }

        private PointF[] pointSorter(PointF[] inputPoints)
        {
            PointF[] sortedPoints = new PointF[4];
            // TR will have smallest X-Y diff
            // BL will have largest X-Y diff
            List<float> diffXY = new List<float>();
            List<float> sumXY = new List<float>();
            for (int i = 0; i < 4; i++)
            {
                diffXY.Add((inputPoints[i].X - inputPoints[i].Y));
                sumXY.Add((inputPoints[i].X + inputPoints[i].Y));
            }
            
            int minSumIdx = sumXY.IndexOf(sumXY.Min()); //TL
            int minDiffIdx = diffXY.IndexOf(diffXY.Min()); // TR
            int maxSumIdx = sumXY.IndexOf(sumXY.Max()); // BL
            int maxDiffIdx = diffXY.IndexOf(diffXY.Max());

            sortedPoints[0] = inputPoints[minSumIdx];
            sortedPoints[1] = inputPoints[minDiffIdx];
            sortedPoints[2] = inputPoints[maxSumIdx];
            sortedPoints[3] = inputPoints[maxDiffIdx];


            return sortedPoints;
        }
        private void inputImagePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (fourCornerPoints.Count < 4)
            {
                Point clickPoint = e.Location;
                int X0, Y0;
                ConvertCoordinates(inputImagePictureBox, out X0, out Y0, clickPoint.X, clickPoint.Y);
                clickPoint = new Point(X0, Y0);

                fourCornerPoints.Add(clickPoint);
                CvInvoke.Circle(dispImage, clickPoint, 2, new MCvScalar(0, 255, 0), 30);
                
                if (fourCornerPoints.Count == 4)
                {
                    PointF[] correctArrPointF = fourCornerPoints.ToArray();
                   
                    Point[] correctArrPoint = new Point[4];
                    for (int i = 0; i < 4; i++)
                        correctArrPoint[i] = new Point((int)correctArrPointF[i].X, (int)correctArrPointF[i].Y);
                    VectorOfPoint vecPoints = new VectorOfPoint(correctArrPoint);

                    for (int i = 3, j = 0; j < 4; i = j++)
                    {
                        CvInvoke.Line(dispImage, new Point((int)correctArrPointF[i].X, (int)correctArrPointF[i].Y), new Point((int)correctArrPointF[j].X, (int)correctArrPointF[j].Y), new MCvScalar(0, 255, 0), 20);
                    }
                    Rectangle boundRect = CvInvoke.BoundingRectangle(vecPoints);
                    CvInvoke.Rectangle(dispImage, boundRect, new MCvScalar(0, 0, 255), 10);
                    PointF[] dst = new[] { new PointF(0, 0), new PointF(boundRect.Width, 0), new PointF(boundRect.Width, boundRect.Height), new PointF(0, boundRect.Height) };
                    
                    var matrix = CvInvoke.GetPerspectiveTransform(correctArrPointF, dst);
                    Mat warpImage = new Mat();
                    CvInvoke.WarpPerspective(inputImage, warpImage, matrix, new Size(boundRect.Width, boundRect.Height), Inter.Cubic);
                    selectedAreaPictureBox.Image = warpImage.Bitmap;
                    segmentedArea = warpImage.Clone();
                }
                inputImagePictureBox.Image = dispImage.Bitmap;
            }
        }
        public static void ConvertCoordinates(PictureBox pic, out int X0, out int Y0, int x, int y)
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
        private void inputImagePictureBox_Click(object sender, EventArgs e)
        {

        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            selectedAreaPictureBox.Image = null;
            dispImage = inputImage.Clone();
            fourCornerPoints.Clear();
            inputImagePictureBox.Image = dispImage.Bitmap;

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
    }
}
