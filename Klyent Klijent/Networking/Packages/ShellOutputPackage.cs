using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klijent.Networking.Packages
{
    class ShellOutputPackage
    {
        public int packageId { get; set; }
        public string shellOutput { get; set; }

        public ShellOutputPackage(string shelloutput)
        {
            packageId = 7;
            shellOutput = shelloutput;
        }

        //Deserijalizacija podataka
        public ShellOutputPackage(byte[] data)
        {
            packageId = BitConverter.ToInt32(data, 0);
            int textMessageLength = BitConverter.ToInt32(data, 4);
            shellOutput = Encoding.UTF8.GetString(data, 8, textMessageLength);
        }

        //Serijalizacija podataka
        public byte[] ToByteArray()
        {
            List<byte> byteList = new List<byte>();
            byteList.AddRange(BitConverter.GetBytes(packageId));
            byteList.AddRange(BitConverter.GetBytes(shellOutput.Length));
            byteList.AddRange(Encoding.UTF8.GetBytes(shellOutput));

            return byteList.ToArray();
        }
    }
}
