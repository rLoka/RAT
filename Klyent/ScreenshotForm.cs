using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace Server
{
    public partial class ScreenshotForm : Form
    {
        Image receivedScreenshot;

        public ScreenshotForm()
        {
            InitializeComponent();
        }

        private void ScreenshotForm_Load(object sender, EventArgs e)
        {

        }

        public void ReceiveScreenshot(Image screenShot/*, string clientComputerName*/)
        {
            receivedScreenshot = screenShot;
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

        private void spremiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {

                using (var m = new MemoryStream())
                {
                    receivedScreenshot.Save(m, ImageFormat.Png);
                    var img = Image.FromStream(m);                    
                    img.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\screenshot.png");
                }
            }
            catch(Exception ex) { }

            MessageBox.Show("Screenshot spremljen kao " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\screenshot.png");
        }
    }
}
