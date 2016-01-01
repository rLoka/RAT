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

    }
}
