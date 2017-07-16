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
    public partial class mainForm : Form
    {
        private VideoCapture fromWebcam;
        private Mat currentVideoFrame,resizedCurrentVideoFrame;
        private int currentInterestedColors = 0;
        public mainForm()
        {
            InitializeComponent();

            // Intialize VideoCapture
            if (fromWebcam == null)
            {
                try
                {
                    fromWebcam = new VideoCapture();
                    currentVideoFrame = new Mat();
                    resizedCurrentVideoFrame = new Mat();
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
                fromCamPictureBox.Image = resizedCurrentVideoFrame.Bitmap;
            }
        }

        private void addInterestedColorBtn_Click(object sender, EventArgs e)
        {
            // Open new Window

            // Return & Add Color to list

            currentInterestedColors += 1;
            string[] tempItemString = new string[3];
            tempItemString[0] = currentInterestedColors.ToString();
            tempItemString[1] = "    ";
            tempItemString[2] = 0.ToString();

            interestedColorList.Items.Add(new ListViewItem(tempItemString));
            interestedColorList.Items[currentInterestedColors - 1].UseItemStyleForSubItems = false;
            interestedColorList.Items[currentInterestedColors - 1].SubItems[1].BackColor = Color.FromArgb(100,100,50);
        }

        private void removeInterestedColorBtn_Click(object sender, EventArgs e)
        {

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
