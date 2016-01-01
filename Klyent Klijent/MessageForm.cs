using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using Klijent.Networking.Packages;

namespace Klijent
{
    public partial class MessageForm : Form
    {
        public MessageForm()
        {
            InitializeComponent();
        }

        public void ReceiveMessage(string messageText)
        {
            string receivedMessageText = messageText;
            AppendReceivedTextMessage(receivedMessageText);
        }

        //Ovo koristimo zbog toga što ne možemo iz druge forme(dretve) postaviti vrijednost neke kontrole
        delegate void AppendReceivedTextMessageCallback(string receivedMessageText);
        private void AppendReceivedTextMessage(string receivedMessageText)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.rtbMessages.InvokeRequired)
            {
                AppendReceivedTextMessageCallback d = new AppendReceivedTextMessageCallback(AppendReceivedTextMessage);
                this.Invoke(d, new object[] { receivedMessageText });
            }
            else
            {
                var date = DateTime.Now;
                this.rtbMessages.AppendText(date.Hour+ ":" + date.Minute + " - Server: " + receivedMessageText + "\r\n");
            }
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {

        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                TextMessagePackage textMessagePackage = new TextMessagePackage(rtbMessageText.Text);
                Form1.ClientSocket.Send(textMessagePackage.ToByteArray());
                rtbMessages.AppendText("Klijent: " + rtbMessageText.Text + "\r\n");
                rtbMessageText.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nije moguće poslati poruku!");
            }
        }

        private void MessageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
