//Klasa NetworkSocket sadrži sve metode potrebne za komunikaciju sa klijentom
/*
Koristimo neblokirajuće (asinkrone) sockete kako bismo mogli komunicirati sav više
klijenata bez da blokiramo glavnu dretvu
*/
using System;
using System.Net;
using System.Collections.Generic;
using System.Net.Sockets;
using Server.Networking.Packages;
using System.Text;
using System.Windows.Forms;
using Server;

namespace Server.Networking
{
    public class ServerSocket
    {
        //Kreiramo socket tipa Socket
        private Socket _socket;

        //Kreiramo buffer za primanje paketa veličine 1024 byta
        byte[] _buffer = new Byte[500000];

        //Konstruktor klase - dodjeljuje vrijednost socketu
        public ServerSocket()
        {
            //Socket(IPV4, TCP=Stream, TCP)
            try
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            catch(Exception ex)
            {
                ShowServerSocketError("Nije moguće otvoriti novi socket!");
            }
        }

        //Metoda za Bindanje socketa na port
        public void Bind(int port)
        {
            //Bindamo socket na bilo koju adresu koju računalo posjeduje i na port u argumentu
            try
            {
                _socket.Bind(new IPEndPoint(IPAddress.Any, port));
            }
            catch (Exception ex)
            {
                ShowServerSocketError("Nije moguće bindati socket na IP adresu/port!");
            }
        }

        //Metoda za slušanje konekcija
        public void Listen(int backlog)
        {
            try
            {
                _socket.Listen(500);
            }
            catch (Exception ex)
            {
                ShowServerSocketError("Nije moguće slušati nove konekcije!");
            }
        }

        //Metoda za prihvaćanje konekcija
        public void Accept()
        {
            try
            {
                _socket.BeginAccept(AcceptedCallback, null);
            }
            catch (Exception ex)
            {
                ShowServerSocketError("Nije moguće prihvaćati nove konekcije!");
            }
        }

        //Metoda koja se poziva kada je uspostavljena konekcija sa klijentom
        private void AcceptedCallback(IAsyncResult result)
        {           
            try
            {
                //Kreiramo novi socket za novog klijenta
                Socket clientSocket = _socket.EndAccept(result);
                //Prihvaćamo klijenta
                Accept();
                _buffer = new byte[500000];
                clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceivedCallback, clientSocket);
            }
            catch (Exception ex)
            {
                ShowServerSocketError("Nije moguće uspostaviti vezu sa klijentom!");
            }
        }

        //Metoda za prihvaćanje podatka koji je primljen
        private void ReceivedCallback(IAsyncResult result)
        {
            Socket clientSocket = result.AsyncState as Socket;
            try
            {
                //Preuzimamo AsyncResult sa ServerSocketa i radimo clientsocket
                int bufferSize = clientSocket.EndReceive(result);
                byte[] packet = new byte[500000];
                Array.Copy(_buffer, packet, packet.Length);                
                PacketHandler.Handle(_buffer, clientSocket);                
                //Brišemo buffer
                _buffer = new byte[500000];
                clientSocket.BeginReceive(_buffer, 0, 500000, SocketFlags.None, ReceivedCallback, clientSocket);
            }
            catch (Exception ex)
            {
                PacketHandler.clientList.Remove(PacketHandler.clientList.Find(client => client.clientSocket == clientSocket));
                clientSocket.Close();
                MessageBox.Show("Krepalo je!", "Bla", MessageBoxButtons.OK);
                //ShowServerSocketError("Nije moguće prihvatiti podatke klijenta!");
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

        //Callback od slanja
        public void SendCallback(IAsyncResult result)
        {
            try
            {
                _socket.EndSend(result);
            }
            catch (Exception ex) { }
        }

        private void ShowServerSocketError(string ErrorMessage)
        {
            System.Windows.Forms.MessageBox.Show(ErrorMessage,
            "Greška",
            System.Windows.Forms.MessageBoxButtons.OK,
            System.Windows.Forms.MessageBoxIcon.Error);
        }

    }
}
