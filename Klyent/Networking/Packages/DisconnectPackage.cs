using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Networking.Packages
{
    class DisconnectPackage
    {
        public int packageId { get; set; }

        public DisconnectPackage()
        {
            packageId = 3;
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
