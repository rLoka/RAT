using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class ScreenshotForm : Form
    {
        string ScreenPath;
        public ScreenshotForm()
        {
            InitializeComponent();
        }

        private void ScreenshotForm_Load(object sender, EventArgs e)
        {

        }

        public void ReceiveScreenshot(Image screenShot/*, string clientComputerName*/)
        {
            Image receivedScreenshot = screenShot;
            ShowReceivedScreenshot(receivedScreenshot);
        }

        //Ovo koristimo zbog toga što ne možemo iz druge forme(dretve) postaviti vrijednost neke kontrole
        delegate void ShowReceivedScreenshotCallback(Image screenShot);
        private void ShowReceivedScreenshot(Image screenShot)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.pictureBox.InvokeRequired)
            {
                ShowReceivedScreenshotCallback d = new ShowReceivedScreenshotCallback(ShowReceivedScreenshot);
                this.Invoke(d, new object[] { screenShot });
            }
            else
            {
                this.pictureBox.Image = screenShot;
            }
        }

        public void screenCapture()
        {

            ScreenPath = "";

            saveFileDialog1.DefaultExt = "bmp";
            saveFileDialog1.Filter = "bmp files (*.bmp)|*.bmp|jpg files (*.jpg)|*.jpg|gif files (*.gif)|*.gif|tiff files (*.tiff)|*.tiff|png files (*.png)|*.png";
            saveFileDialog1.Title = "Save screenshot to...";
            saveFileDialog1.ShowDialog();
            ScreenPath = saveFileDialog1.FileName;

            /*
            if (ScreenPath != "" || ScreenShot.saveToClipboard)
            {

                //Conceal this form while the screen capture takes place
                this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                this.TopMost = false;

                //Allow 250 milliseconds for the screen to repaint itself (we don't want to include this form in the capture)
                System.Threading.Thread.Sleep(250);

                Rectangle bounds = Screen.GetBounds(Screen.GetBounds(Point.Empty));
                string fi = "";

                if (ScreenPath != "")
                {

                    fi = new FileInfo(ScreenPath).Extension;

                }

                ScreenShot.CaptureImage(showCursor, curSize, curPos, Point.Empty, Point.Empty, bounds, ScreenPath, fi);

                //The screen has been captured and saved to a file so bring this form back into the foreground
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                this.TopMost = true;

                if (ScreenShot.saveToClipboard)
                {

                    MessageBox.Show("Screen saved to clipboard", "TeboScreen", MessageBoxButtons.OK);

                }
                else
                {

                    MessageBox.Show("Screen saved to file", "TeboScreen", MessageBoxButtons.OK);

                }
                
            }*/

        }

        private void btnSaveSS_Click_1(object sender, EventArgs e)
        {
            //MessageBox.Show("Radi!", "Bla", MessageBoxButtons.OK);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            //screenCapture();
        }
    }
}
