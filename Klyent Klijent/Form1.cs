using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Klijent.Networking;
using System.Net.Sockets;

namespace Klijent
{
    public partial class Form1 : Form
    {
        public static ClientSocket ClientSocket = new ClientSocket();
        private static string ipAddress;
        private static int port;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ipAddress = tbIPAddress.Text;
            port = Int32.Parse(tbPort.Text);
            connectionTimer.Enabled = true;
            connectionTimer.Start();            
        }

        private void tbIPAddress_TextChanged(object sender, EventArgs e)
        {
            if(tbIPAddress.Text == "")
            {
                btnConnect.Enabled = false;
            }
            else
            {
                btnConnect.Enabled = true;
            }
        }

        private void tbPort_TextChanged(object sender, EventArgs e)
        {
            if (tbPort.Text == "")
            {
                btnConnect.Enabled = false;
            }
            else
            {
                btnConnect.Enabled = true;
            }
        }

        private void connectionTimer_Tick(object sender, EventArgs e)
        {
            //TcpClient tcpClient = new TcpClient();
            //try
            //{
                //tcpClient.Connect(ipAddress, port);
                //Console.WriteLine("Server online");
                if (!ClientSocket._socket.Connected)
                {
                    try
                    {
                        ClientSocket.Connect(ipAddress, port);
                        Console.WriteLine("Spojen!");
                        //connectionTimer.Stop();
                    }
                    catch
                    {
                        Console.WriteLine("Nije spojen!");
                    }
                }
            //}
            //catch (Exception)
            //{
                //Console.WriteLine("Server online");
            //}            
        }

        bool isSocketConnected(Socket clientSocket)
        {
            bool socketState = clientSocket.Poll(1000, SelectMode.SelectRead);
            bool socketAvailbility = (clientSocket.Available == 0);
            if (socketState && socketAvailbility)
                return false;
            else
                return true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ClientSocket != null)
            {
                ClientSocket.CloseSocket();
            }
        }
    }
}
