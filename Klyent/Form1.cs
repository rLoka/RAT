using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Server.Networking;
using Server.ClientData;
using System.Net.Sockets;
using Server.Networking.Packages;
using System.Drawing;

namespace Server
{
    public partial class Form1 : Form
    {
        public int defaultPort;
        public static ServerSocket ServerSocket = new ServerSocket();
        public static DataTable dataGrid = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        //Metoda koja se izvršava pri pokretanju programa
        private void Form1_Load(object sender, EventArgs e)
        {
            //Popunjavamo tablicu sa stupcima
            populateTableColumns();
            menuStrip.ImageList = imageList;
        }

        //Metoda koja popunjava stupce
        private void populateTableColumns()
        {
            dataGrid.Columns.Add("ID", typeof(int));
            dataGrid.Columns.Add("Računalo", typeof(string));
            dataGrid.Columns.Add("IP adresa", typeof(string));
            dataGrid.Columns.Add("Status", typeof(string));
            connectionList.DataSource = dataGrid;
        }

        //Metoda koja čita vrijednost textboxa tbPort i postavlja ga u globalnu varijablu
        private void btnPostaviPort_Click(object sender, EventArgs e)
        {
            try
            {
                defaultPort = Int32.Parse(tbPort.Text);
                btnSlusajKonekcije.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Port nije valjanog oblika!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        //Metoda koja se poziva kod promjene sadržaja textboxa porta
        private void tbPort_TextChanged(object sender, EventArgs e)
        {
            //Ako je textbox ostavljen prazan ne dopuštamo postavljanje porta
            if (tbPort.Text == "")
            {
                btnPostaviPort.Enabled = false;
            }
            else
            {
                btnPostaviPort.Enabled = true;
            }
        }
        //Metoda koja onemogućuje korištenje mogućnosti ako nijedna konekcija nije odabrana
        private void cntxtMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            bool selectionStatus;
            if (connectionList.SelectedCells.Count == 0 && connectionList.SelectedRows.Count == 0)
            {
                selectionStatus = false;
            }
            else
            {
                selectionStatus = true;
            }

            btnSendMessage.Enabled = selectionStatus;
            btnSlanjeDat.Enabled = selectionStatus;
            btnOdspojiKlijenta.Enabled = selectionStatus;
            btnTakeScreenshot.Enabled = selectionStatus;
        }

        //Metoda koja binda socket i sluša konekcije
        private void btnSlusajKonekcije_Click(object sender, EventArgs e)
        {
            try
            {
                //Server socket prvo bindamo na port
                ServerSocket.Bind(defaultPort);
                //Slušamo ulazne konekcije
                ServerSocket.Listen(500);
                //Prihvaćamo konekcije
                ServerSocket.Accept();
                lblStatusLabel.Text = "Slušam konekcije na portu " + defaultPort;
                btnRefreshClientList_Click();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Trenutno nije moguće slušati na konekcije!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        //Metoda koja se izvršava kada pritisnemo osvježi 
        private void btnRefreshClientList_Click(object sender = null, EventArgs e = null)
        {
            var i = 0;
            dataGrid.Rows.Clear();
            PacketHandler.clientList.ForEach(delegate (Client client)
            {
                dataGrid.Rows.Add(i++, client.clientComputerName, client.clientIPAddress, client.clientOsVersion);
            });
        }
        //Metoda koja šalje tektualne poruke klijentu
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRowIndex = connectionList.SelectedCells[0].RowIndex;//.SelectedRows[0].Index;
                var clientSocket = PacketHandler.clientList.ElementAt(selectedRowIndex).clientSocket;
                if (!PacketHandler.openedMessageForms.ContainsKey(clientSocket))
                {
                    MessageForm NewMessageForm = new MessageForm(clientSocket);
                    PacketHandler.openedMessageForms.Add(clientSocket, NewMessageForm);
                    NewMessageForm.Show();
                    Application.Run();
                }
                else
                {
                    MessageForm NewMessageForm = PacketHandler.openedMessageForms[clientSocket];
                    NewMessageForm.Show();
                    Application.Run();
                }
            }
            catch (Exception ex)
            {
                /*
                MessageBox.Show("Slanje poruke nije uspjelo!",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    */
            }
        }

        private void btnSlanjeDat_Click(object sender, EventArgs e)
        {
            //var selectedRowIndex = connectionList.SelectedCells[0].RowIndex;
            //var clientSocket = PacketHandler.clientList.ElementAt(selectedRowIndex).clientSocket;
        }
        //Tajmer koji iterira kroz listu spojenih klijenata i provjerava da li su klijenti aktivni
        private void timerCheckForConnectedClients_Tick(object sender, EventArgs e)
        {
            //PacketHandler.clientList.ForEach(delegate (Client client)
            foreach (Client client in PacketHandler.clientList.ToList())
            {
                if (!isSocketConnected(client.clientSocket))
                {
                    PacketHandler.clientList.Remove(client);
                    dataGrid.Rows.Clear();
                }
            }
            if (PacketHandler.clientList.Count() != connectionList.Rows.Count)
            {
                dataGrid.Rows.Clear();
                var i = 0;
                foreach (Client client in PacketHandler.clientList.ToList())
                {
                    dataGrid.Rows.Add(i++, client.clientComputerName, client.clientIPAddress, client.clientOsVersion);
                }
            }
        }

        //Metoda koja provjerava da li je klijent još uvijek spojen
        bool isSocketConnected(Socket clientSocket)
        {
            bool socketState = clientSocket.Poll(1000, SelectMode.SelectRead);
            bool socketAvailbility = (clientSocket.Available == 0);
            if (socketState && socketAvailbility)
                return false;
            else
                return true;
        }

        private void btnOdspojiKlijenta_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRowIndex = connectionList.SelectedCells[0].RowIndex;
                var clientSocket = PacketHandler.clientList.ElementAt(selectedRowIndex).clientSocket;
                DisconnectPackage newDisconnectPackage = new DisconnectPackage();
                clientSocket.BeginSend(newDisconnectPackage.ToByteArray(), 0, newDisconnectPackage.ToByteArray().Length, SocketFlags.None, new AsyncCallback(SendCallback), null);
                clientSocket.Close();
                Client clientForDisconnection = PacketHandler.clientList.Find(client => client.clientSocket == clientSocket);
                PacketHandler.clientList.Remove(clientForDisconnection);
            }
            catch (Exception ex)
            { }
        }

        public void SendCallback(IAsyncResult result)
        {
            try
            {
                Console.WriteLine("Poslano!");
            }
            catch (Exception ex) { }
        }

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            foreach (Client client in PacketHandler.clientList.ToList())
            {
                client.clientSocket.Close();
            }
            Application.Exit();
        }

        private void btnTakeScreenshot_Click(object sender, EventArgs e)
        {
            
            RequestPackage requestPackage = new RequestPackage(4);
            var selectedRowIndex = connectionList.SelectedCells[0].RowIndex;
            var clientSocket = PacketHandler.clientList.ElementAt(selectedRowIndex).clientSocket;
            clientSocket.Send(requestPackage.ToByteArray());
        }
    }
}
