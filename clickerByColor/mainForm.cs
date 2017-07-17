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
    public partial class mainForm : Form
    {
        private VideoCapture fromWebcam;
        private Mat currentVideoFrame,resizedCurrentVideoFrame, blurOriginalCurrentVideoFrame, hsvVideoFrame;
        private int currentInterestedColors = 0;
        private List<RangeF> interestedColors = new List<RangeF>();
        private List<int> blobCount = new List<int>();
        public mainForm()
        {
            InitializeComponent();

            // Intialize VideoCapture
            if (fromWebcam == null)
            {
                try
                {
                    fromWebcam = new VideoCapture(0);
                    currentVideoFrame = new Mat();
                    resizedCurrentVideoFrame = new Mat();
                    blurOriginalCurrentVideoFrame = new Mat();
                    hsvVideoFrame = new Mat();
                }
                catch (NullReferenceException excpt)
                {
                    // Cannot open camera throw error
                    MessageBox.Show(excpt.Message);
                }
            }

            // Attach VideoCapture callback to function
            fromWebcam.ImageGrabbed += frameProcessor;
            fromWebcam.SetCaptureProperty(CapProp.FrameWidth, 1360);
            fromWebcam.SetCaptureProperty(CapProp.FrameHeight, 768);
            fromWebcam.Start();
        }

        private void frameProcessor(object sender, EventArgs e)
        {
            // Retreive frame from webcam
            if (fromWebcam.Retrieve(currentVideoFrame, 0))
            {
                // Resize should preserve aspect ratio
                resizedCurrentVideoFrame = keepAspectRatioResize(currentVideoFrame, new Size(fromCamPictureBox.Width,fromCamPictureBox.Height));

                //CvInvoke.Blur(resizedCurrentVideoFrame, blurOriginalCurrentVideoFrame, new Size(3, 3), new Point(-1, -1));
                CvInvoke.MedianBlur(resizedCurrentVideoFrame, blurOriginalCurrentVideoFrame, 7);
                CvInvoke.CvtColor(blurOriginalCurrentVideoFrame, hsvVideoFrame, ColorConversion.Bgr2Hsv);
                Mat[] hsvImageChannels = hsvVideoFrame.Split();
                // Iterate over defined color range
                for (int colorRange = 0;colorRange< interestedColors.Count; colorRange++)
                {
                    Mat segmentationResultMat = new Mat();
                    CvInvoke.InRange(hsvImageChannels[0], new ScalarArray(interestedColors[colorRange].Min), new ScalarArray(interestedColors[colorRange].Max), segmentationResultMat);

                    VectorOfVectorOfPoint currentColorContours = new VectorOfVectorOfPoint();
                    CvInvoke.FindContours(segmentationResultMat, currentColorContours, null, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
                    int currentColorBlob = 0;
                    for (int contourNo = 0; contourNo < currentColorContours.Size; contourNo++)
                    {
                       
                        double currentContourArea = CvInvoke.ContourArea(currentColorContours[contourNo]);
                        if (currentContourArea > resizedCurrentVideoFrame.Width*resizedCurrentVideoFrame.Height*0.01) {
                            Rectangle contourBBox = CvInvoke.BoundingRectangle(currentColorContours[contourNo]);
                            CvInvoke.DrawContours(resizedCurrentVideoFrame, currentColorContours, contourNo, new MCvScalar(0, 255, 0), 2);
                            MCvMoments contourMoment = CvInvoke.Moments(currentColorContours[contourNo]);
                            Point weightedCentroid = new Point((int)(contourMoment.M10 / contourMoment.M00), (int)(contourMoment.M01 / contourMoment.M00));
                            CvInvoke.PutText(resizedCurrentVideoFrame,(colorRange+1).ToString(), weightedCentroid, FontFace.HersheyComplexSmall,1.0,new Bgr(0, 0, 255).MCvScalar);
                            currentColorBlob++;
                        }
                    }
                    /*this.interestedColorList.Invoke((MethodInvoker)delegate {
                        // Running on the UI thread
                        this.interestedColorList.Items[colorRange].SubItems[2].Text = currentColorBlob.ToString();
                    });*/
                    blobCount[colorRange] = currentColorBlob;
                    
                }

                fromCamPictureBox.Image = resizedCurrentVideoFrame.Bitmap;
            }
            else
            {
                //No Frame Retreive, reopen camera
                fromWebcam.Stop();
                fromWebcam.Start();
            }
        }

        private void addInterestedColorBtn_Click(object sender, EventArgs e)
        {
            // Open new Window
            RangeF hueRange = new RangeF();
            selectColorForm mySelectColorForm = new selectColorForm(resizedCurrentVideoFrame, ref hueRange);
            mySelectColorForm.ShowDialog();
            if (mySelectColorForm.DialogResult == DialogResult.OK)
            {
                interestedColors.Add(mySelectColorForm.hueRange);
                blobCount.Add(0);
                rewriteColorList();
            }
        }

        private void blobCountUpdater_Tick(object sender, EventArgs e)
        {
            for (int colorRange = 0; colorRange < interestedColors.Count; colorRange++)
            {
                interestedColorList.Items[colorRange].SubItems[2].Text = blobCount[colorRange].ToString();
            }
        }

        private void rewriteColorList()
        {
            interestedColorList.Items.Clear();
            for (int colorNo =0;colorNo< interestedColors.Count; colorNo++)
            {
                string[] tempItemString = new string[3];
                tempItemString[0] = (colorNo+1).ToString();
                tempItemString[1] = "    ";
                tempItemString[2] = blobCount[colorNo].ToString();
                interestedColorList.Items.Add(new ListViewItem(tempItemString));
                interestedColorList.Items[colorNo].UseItemStyleForSubItems = false;

                Image<Hsv, byte> hsvImage = new Image<Hsv, byte>(1, 1, new Hsv((interestedColors[colorNo].Min + interestedColors[colorNo].Max) / 2.0, 255, 255));
                Image<Rgb, byte> rgbImage = hsvImage.Convert<Rgb, byte>();
                Rgb showRgbColor = rgbImage[0, 0];
                interestedColorList.Items[colorNo].SubItems[1].BackColor = Color.FromArgb((int)showRgbColor.Red, (int)showRgbColor.Green, (int)showRgbColor.Blue);
            }
        }
        private void removeInterestedColorBtn_Click(object sender, EventArgs e)
        {
            if(interestedColorList.Items.Count > 0)
            {
                interestedColors.RemoveAt(interestedColorList.SelectedIndices[0]);
                blobCount.Remove(interestedColorList.SelectedIndices[0]);
                interestedColorList.Items.RemoveAt(interestedColorList.SelectedIndices[0]);
                rewriteColorList();
            }
        }

        private Mat keepAspectRatioResize(Mat inputImage, Size targetSize,int padColor = 0)
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
