using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server.Networking.Packages
{
    class ShellCommandPackage
    {
        public int packageId { get; set; }
        public string shellCommand { get; set; }

        public ShellCommandPackage(string shellcommand)
        {
            packageId = 6;
            shellCommand = shellcommand;
        }

        //Deserijalizacija podataka
        public ShellCommandPackage(byte[] data)
        {
            packageId = BitConverter.ToInt32(data, 0);
            int textMessageLength = BitConverter.ToInt32(data, 4);
            shellCommand = Encoding.UTF8.GetString(data, 8, textMessageLength);
        }

        //Serijalizacija podataka
        public byte[] ToByteArray()
        {
            List<byte> byteList = new List<byte>();
            byteList.AddRange(BitConverter.GetBytes(packageId));
            byteList.AddRange(BitConverter.GetBytes(shellCommand.Length));
            byteList.AddRange(Encoding.UTF8.GetBytes(shellCommand));

            return byteList.ToArray();
        }
    }
}
