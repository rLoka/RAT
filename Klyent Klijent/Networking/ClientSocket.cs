using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Klijent.Networking
{
    //Clientsocket je klasa u kojoj su implementriane metode za spajanje sa serverom
    public class ClientSocket
    {
        //Kreiramo socket tipa Socket
        public Socket _socket;

        //Kreiramo buffer za primanje paketa veličine 1024 byta
        byte[] _buffer = new Byte[500000];

        //Konstruktor klase - dodjeljuje vrijednost socketu
        public ClientSocket()
        {            
            try
            {
                //Socket(IPV4, TCP=Stream, TCP)
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            catch (Exception ex)
            {
                ShowClientSocketError("Nije moguće otvoriti novi socket!");
            }
        }
        //Metoda kojom se spajamo na server
        public void Connect(string ipAddress, int port)
        {            
            try
            {                
                _socket.BeginConnect(new IPEndPoint(IPAddress.Parse(ipAddress), port), ConnectCallback, null);

            }
            catch (Exception ex)
            {
                // ShowClientSocketError("Nije se moguće spojiti na server!");
            }
        }
        //Metoda koja se poziva kada se spojimo na server
        public void ConnectCallback(IAsyncResult result)
        {
            try
            {
                //Slanje inicijalnog paketa sa informacijama o sebi kao klijentu
                Send(PacketHandler.SendClientInfoToServer());
                _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceivedCallback, null);
            }
            catch (Exception ex)
            {
                //ShowClientSocketError("Nije se moguće poslati inicijalne podatke serveru!");
                try {
                    _socket.Disconnect(true);
                }
                catch (Exception exx) { }
            }
        }

        //Metoda za prihvaćanje podataka
        private void ReceivedCallback(IAsyncResult result)
        {
            try { 
            int bufLength = _socket.EndReceive(result);
            byte[] packet = new byte[bufLength];
            Array.Copy(_buffer, packet, packet.Length);
            PacketHandler.Handle(_buffer, _socket);
            _buffer = new byte[_socket.ReceiveBufferSize];
            _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceivedCallback, null);
            }
            catch (Exception ex)
            {
                try {
                    _socket.Disconnect(true);
                }
                catch (Exception exx) { }
                //_socket.Close();
                //ShowClientSocketError("Nije se moguće primiti podatke od servera!");
            }
        }

        //Metoda za slanje paketa
        public void Send(byte[] buffer)
        {
            try
            {
                _socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(SendCallback), null);
            }
            catch (Exception ex) { }
        }

        //Callback od slanja - poziva se nakon slanja
        public void SendCallback(IAsyncResult result)
        {
            try
            {
                //Vraća broj poslanih byteva
                _socket.EndSend(result);
            }
            catch (Exception ex) { }
        }

        //Metoda koju pozivamo kad hoćemo zatvoriti socket
        public void CloseSocket()
        {
            _socket.Close();
        }

        //Metoda za ispis pogreške tijekom slanja
        private void ShowClientSocketError(string ErrorMessage)
        {
            System.Windows.Forms.MessageBox.Show(ErrorMessage,
            "Greška",
            System.Windows.Forms.MessageBoxButtons.OK,
            System.Windows.Forms.MessageBoxIcon.Error);
        }
    }
}
