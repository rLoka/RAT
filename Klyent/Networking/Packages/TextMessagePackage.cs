using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Networking.Packages
{
    class TextMessagePackage
    {
        public int packageId { get; set; }
        public string textMessage { get; set; }

        public TextMessagePackage(string textmessage)
        {
            packageId = 2;
            textMessage = textmessage;
        }

        //Deserijalizacija podataka
        public TextMessagePackage(byte[] data)
        {
            packageId = BitConverter.ToInt32(data, 0);
            int textMessageLength = BitConverter.ToInt32(data, 4);
            textMessage = Encoding.UTF8.GetString(data, 8, textMessageLength);
        }

        //Serijalizacija podataka
        public byte[] ToByteArray()
        {
            List<byte> byteList = new List<byte>();
            byteList.AddRange(BitConverter.GetBytes(packageId));
            byteList.AddRange(BitConverter.GetBytes(textMessage.Length));
            byteList.AddRange(Encoding.UTF8.GetBytes(textMessage));

            return byteList.ToArray();
        }
    }
}
