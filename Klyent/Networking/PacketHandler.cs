﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using Server.Networking.Packages;
using System.Net;
using Server.ClientData;
using System.Windows.Forms;

namespace Server.Networking
{

    public static class PacketHandler
    {
        public static List<Client> clientList = new List<Client>();
        public static Dictionary<Socket, MessageForm> openedMessageForms = new Dictionary<Socket, MessageForm>();

        //Metoda koja hendla pristigle paket
        public static void Handle(byte[] receivedPacket, Socket clientSocket)
        {
            int packetId = BitConverter.ToInt32(receivedPacket, 0);
            Console.WriteLine(packetId);
            switch (packetId)
            {
                //ClientInfoPackage = 1
                case 1:
                    ClientInfoPackatHandler(receivedPacket, clientSocket);
                    break;
                //TextMessagePackage = 2
                case 2:
                    TextMessagePacketHandler(receivedPacket, clientSocket);
                    break;
                case 5:
                    ScreenshotPacketHandler(receivedPacket, clientSocket);
                    break;
            }
        }

        private static void ClientInfoPackatHandler(byte[] receivedPacket, Socket clientSocket)
        {
            ClientInfoPackage clientInfoPackage = new ClientInfoPackage(receivedPacket);
            Client client = new Client();
            IPEndPoint remoteIpEndPoint = clientSocket.RemoteEndPoint as IPEndPoint;
            client.SetClientProperties(remoteIpEndPoint.Address.ToString(),
                clientInfoPackage.clientComputerName,
                clientInfoPackage.clientOsVersion,
                clientSocket
                );
            clientList.Add(client);
        }

        private static void TextMessagePacketHandler(byte[] receivedPacket, Socket clientSocket)
        {
            //Radimo konverziju primljenog paketa (lambda expressions)
            TextMessagePackage textMessagePackage = new TextMessagePackage(receivedPacket);
            
            //Identificiramo klijenta koji je poslao poruku po socketu
            Client clientThatSentMessage = clientList.Find(client => client.clientSocket == clientSocket);

            if (!openedMessageForms.ContainsKey(clientSocket))
            {
                MessageForm NewMessageForm = new MessageForm(clientSocket);
                openedMessageForms.Add(clientSocket, NewMessageForm);
                NewMessageForm.ReceiveMessage(textMessagePackage.textMessage, clientThatSentMessage.clientComputerName);
                NewMessageForm.Show();                
                Application.Run();                
            }
            else
            {
                MessageForm NewMessageForm = openedMessageForms[clientSocket];
                NewMessageForm.Show();
                //Application.Run();
                NewMessageForm.ReceiveMessage(textMessagePackage.textMessage, clientThatSentMessage.clientComputerName);
            }
        }

        private static void ScreenshotPacketHandler(byte[] receivedPacket, Socket clientSocket)
        {
            ScreenshotPackage screenshotPackage = new ScreenshotPackage(receivedPacket);
            ScreenshotForm NewScreenshotForm = new ScreenshotForm();
            NewScreenshotForm.ReceiveScreenshot(screenshotPackage.screenShot);
            NewScreenshotForm.ShowDialog();
            //Application.Run();
        }
    }
}
