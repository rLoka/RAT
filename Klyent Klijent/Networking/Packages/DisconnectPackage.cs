using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klijent.Networking.Packages
{
    class DisconnectPackage
    {
        public int packageId { get; set; }

        //Deserijalizacija podataka
        public DisconnectPackage(byte[] data)
        {
            packageId = BitConverter.ToInt32(data, 0);
        }

        //Serijalizacija podataka
        public byte[] ToByteArray()
        {
            List<byte> byteList = new List<byte>();
            byteList.AddRange(BitConverter.GetBytes(packageId));

            return byteList.ToArray();
        }
    }
}
