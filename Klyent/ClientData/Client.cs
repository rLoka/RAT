using System.Net.Sockets;

namespace Server.ClientData
{
    /*
    Klasa Client služi za spremanje informacija o klijentima.
    Za svakog klijenta koji se spoji sprema se IP adresa, ime računala, OS i klijentski socket.
    */
    public class Client
    {
        public string clientIPAddress {get; set;}
        public string clientComputerName {get; set;}
        public string clientOsVersion {get; set;}
        public Socket clientSocket {get; set;}

        public void SetClientProperties(string ip, string computername, string os, Socket socket)
        {
            clientIPAddress = ip;
            clientComputerName = computername;
            clientOsVersion = os;
            clientSocket = socket;
        }
    }
}
