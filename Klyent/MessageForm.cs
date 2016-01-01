using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server.Networking.Packages;


namespace Server
{
    public partial class MessageForm : Form
    {
        public Socket clientSocket;
        public MessageForm(Socket newClientSocket)
        {
            InitializeComponent();
            clientSocket = newClientSocket;
        }

        public void ReceiveMessage(string messageText, string clientComputerName)
        {
            string receivedMessageText = clientComputerName + ":" + messageText;
            AppendReceivedTextMessage(receivedMessageText);            
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {

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
                this.rtbMessages.AppendText(date.Hour + ":" + date.Minute + " " + receivedMessageText + "\r\n");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try {
            TextMessagePackage textMessagePackage = new TextMessagePackage(rtbMessageText.Text);
            clientSocket.BeginSend(textMessagePackage.ToByteArray(), 0, textMessagePackage.ToByteArray().Length, SocketFlags.None, new AsyncCallback(SendCallback), null);
            rtbMessages.AppendText("Ja: " + rtbMessageText.Text + "\r\n");
            rtbMessageText.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Slanje poruke nije uspjelo!");
            }
        }

        public void SendCallback(IAsyncResult result)
        {
            try
            {
                Console.WriteLine("Poslano byteva: " + clientSocket.EndSend(result));
            }
            catch (Exception ex) { }
        }

        private void MessageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
