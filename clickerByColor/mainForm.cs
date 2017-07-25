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
        private List<double> blobCount = new List<double>();
        public mainForm()
        {
            InitializeComponent();

            // Intialize VideoCapture
            /*
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
            fromWebcam.SetCaptureProperty(CapProp.FrameWidth, 1920);
            fromWebcam.SetCaptureProperty(CapProp.FrameHeight, 1080);
            fromWebcam.Start();
            */
            resizedCurrentVideoFrame = new Mat();
            blurOriginalCurrentVideoFrame = new Mat();
            hsvVideoFrame = new Mat();
        }
        
        private void frameProcessor(object sender, EventArgs e)
        {
            // Retreive frame from webcam
            if (fromWebcam.Retrieve(currentVideoFrame, 0))
            {
                // Resize should preserve aspect ratio
                resizedCurrentVideoFrame = keepAspectRatioResize(currentVideoFrame, new Size(fromCamPictureBox.Width,fromCamPictureBox.Height));

                //CvInvoke.Blur(resizedCurrentVideoFrame, blurOriginalCurrentVideoFrame, new Size(3, 3), new Point(-1, -1));
                CvInvoke.MedianBlur(resizedCurrentVideoFrame, blurOriginalCurrentVideoFrame, 5);
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
                    double sumContour = 0;
                    for (int contourNo = 0; contourNo < currentColorContours.Size; contourNo++)
                    {
                       
                        double currentContourArea = CvInvoke.ContourArea(currentColorContours[contourNo]);
                        if (currentContourArea > resizedCurrentVideoFrame.Width*resizedCurrentVideoFrame.Height*0.0003 &&
                            currentContourArea < resizedCurrentVideoFrame.Width * resizedCurrentVideoFrame.Height * 0.5) {
                            sumContour += currentContourArea;
                            Rectangle contourBBox = CvInvoke.BoundingRectangle(currentColorContours[contourNo]);
                            CvInvoke.DrawContours(resizedCurrentVideoFrame, currentColorContours, contourNo, new MCvScalar(0, 255, 0), 2);
                            MCvMoments contourMoment = CvInvoke.Moments(currentColorContours[contourNo]);
                            Point weightedCentroid = new Point((int)(contourMoment.M10 / contourMoment.M00), (int)(contourMoment.M01 / contourMoment.M00));
                            CvInvoke.PutText(resizedCurrentVideoFrame,(colorRange+1).ToString(), weightedCentroid, FontFace.HersheyComplexSmall,4.0,new Bgr(0, 0, 255).MCvScalar);
                            currentColorBlob++;
                        }
                    }
                    // Use timer to update UI blob count
                    blobCount[colorRange] = ( sumContour/(currentVideoFrame.Rows*currentVideoFrame.Cols));
                }

                fromCamPictureBox.Image = resizedCurrentVideoFrame.Bitmap;
            }
            else
            {
                //No Frame Retreive, reopen camera => Something may be happen (VirtualBox bug)
                System.Console.WriteLine("No Frame");
            }
        }

        private void addInterestedColorBtn_Click(object sender, EventArgs e)
        {
            if (currentVideoFrame != null)
            {
                // Open new Window
                RangeF hueRange = new RangeF();
                selectColorForm mySelectColorForm = new selectColorForm(currentVideoFrame, ref hueRange);
                mySelectColorForm.ShowDialog();
                if (mySelectColorForm.DialogResult == DialogResult.OK)
                {
                    interestedColors.Add(mySelectColorForm.hueRange);
                    blobCount.Add(0);
                    rewriteColorList();
                    segmentOneShot();
                }
            }
        }

        private void blobCountUpdater_Tick(object sender, EventArgs e)
        {
            for (int colorRange = 0; colorRange < interestedColors.Count; colorRange++)
            {
                
                interestedColorList.Items[colorRange].SubItems[1].Text = (Math.Truncate(blobCount[colorRange] * 100) / 100).ToString();
                if (numPersonTextBox.Text.Length > 0)
                {
                    interestedColorList.Items[colorRange].SubItems[2].Text = ((int)( (blobCount[colorRange] * Convert.ToInt32(numPersonTextBox.Text)) / 100)).ToString();
                }
                else
                {
                    interestedColorList.Items[colorRange].SubItems[2].Text = "ERR";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openImageFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Mat tempFrame = new Mat(openImageFileDialog.FileName);
                    // Select Area!!!
                    defineArea newDefineArea = new defineArea(tempFrame);
                    if(newDefineArea.ShowDialog() == DialogResult.OK)
                    {
                        currentVideoFrame = newDefineArea.segmentedArea.Clone();
                        fromCamPictureBox.Image = currentVideoFrame.Bitmap;
                        interestedColors.Clear();
                        blobCount.Clear();
                        rewriteColorList();
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void segmentOneShot()
        {
            if (currentVideoFrame != null)
            {
                CvInvoke.MedianBlur(currentVideoFrame, blurOriginalCurrentVideoFrame, 5);
                CvInvoke.CvtColor(blurOriginalCurrentVideoFrame, hsvVideoFrame, ColorConversion.Bgr2Hsv);
                Mat[] hsvImageChannels = hsvVideoFrame.Split();
                Mat tempImage = currentVideoFrame.Clone();
                // Iterate over defined color range
                for (int colorRange = 0; colorRange < interestedColors.Count; colorRange++)
                {
                    Mat segmentationResultMat = new Mat();
                    CvInvoke.InRange(hsvImageChannels[0], new ScalarArray(interestedColors[colorRange].Min), new ScalarArray(interestedColors[colorRange].Max), segmentationResultMat);
                    double sumArea = segmentationResultMat.ToImage<Gray,Byte>().CountNonzero()[0];
                    Image<Hsv, byte> hsvImage = new Image<Hsv, byte>(1, 1, new Hsv((interestedColors[colorRange].Min + interestedColors[colorRange].Max) / 2.0, 255, 255));
                    Image<Rgb, byte> rgbImage = hsvImage.Convert<Rgb, byte>();
                    Rgb showRgbColor = rgbImage[0, 0];
                    tempImage.SetTo(new MCvScalar(showRgbColor.Blue, showRgbColor.Green, showRgbColor.Red), segmentationResultMat);
                    /*
                    VectorOfVectorOfPoint currentColorContours = new VectorOfVectorOfPoint();
                    CvInvoke.FindContours(segmentationResultMat, currentColorContours, null, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
                    int currentColorBlob = 0;
                    
                    for (int contourNo = 0; contourNo < currentColorContours.Size; contourNo++)
                    {

                        double currentContourArea = CvInvoke.ContourArea(currentColorContours[contourNo]);
                        /*if (currentContourArea > currentVideoFrame.Width * currentVideoFrame.Height * 0.0003 &&
                            currentContourArea < currentVideoFrame.Width * currentVideoFrame.Height * 0.5)
                        {
                            sumContour += currentContourArea;
                            Rectangle contourBBox = CvInvoke.BoundingRectangle(currentColorContours[contourNo]);

                            Image<Hsv, byte> hsvImage = new Image<Hsv, byte>(1, 1, new Hsv((interestedColors[colorRange].Min + interestedColors[colorRange].Max) / 2.0, 255, 255));
                            Image<Rgb, byte> rgbImage = hsvImage.Convert<Rgb, byte>();
                            Rgb showRgbColor = rgbImage[0, 0];

                            CvInvoke.DrawContours(tempImage, currentColorContours, contourNo, new MCvScalar(showRgbColor.Blue, showRgbColor.Green, showRgbColor.Red), 2);
                            currentColorBlob++;
                        //}
                    }*/
                    // Use timer to update UI blob count
                    blobCount[colorRange] = (sumArea / (currentVideoFrame.Rows * currentVideoFrame.Cols))*100;
                }
                fromCamPictureBox.Image = tempImage.Bitmap;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void numPersonTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            
        }

        private void rewriteColorList()
        {
            interestedColorList.Items.Clear();
            for (int colorNo =0;colorNo< interestedColors.Count; colorNo++)
            {
                string[] tempItemString = new string[3];

                tempItemString[0] = "    ";
                tempItemString[1] = blobCount[colorNo].ToString();
                if (numPersonTextBox.Text.Length > 0)
                {
                    tempItemString[2] = ((int)((blobCount[colorNo] * Convert.ToInt32(numPersonTextBox.Text)) / 100)).ToString();
                }
                else
                {
                    tempItemString[2] = "ERR";
                }
                interestedColorList.Items.Add(new ListViewItem(tempItemString));
                interestedColorList.Items[colorNo].UseItemStyleForSubItems = false;

                Image<Hsv, byte> hsvImage = new Image<Hsv, byte>(1, 1, new Hsv((interestedColors[colorNo].Min + interestedColors[colorNo].Max) / 2.0, 255, 255));
                Image<Rgb, byte> rgbImage = hsvImage.Convert<Rgb, byte>();
               
                Rgb showRgbColor = rgbImage[0, 0];
                interestedColorList.Items[colorNo].SubItems[0].BackColor = Color.FromArgb((int)showRgbColor.Red, (int)showRgbColor.Green, (int)showRgbColor.Blue);
            }
        }
        private void removeInterestedColorBtn_Click(object sender, EventArgs e)
        {
            if(interestedColorList.Items.Count > 0 && interestedColorList.SelectedIndices.Count > 0)
            {

                 interestedColors.RemoveAt(interestedColorList.SelectedIndices[0]);
                 blobCount.Remove(interestedColorList.SelectedIndices[0]);
                    interestedColorList.Items.RemoveAt(interestedColorList.SelectedIndices[0]);
                    segmentOneShot();
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
