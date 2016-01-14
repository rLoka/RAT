using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Networking.Packages
{
    class PathPackage
    {
        public int packageId { get; set; }
        public int pathId { get; set; }

        public PathPackage(int pathid)
        {
            packageId = 8;
            pathId = pathid;
        }

        //Deserijalizacija podataka
        public PathPackage(byte[] data)
        {
            packageId = BitConverter.ToInt32(data, 0);
            pathId = BitConverter.ToInt32(data, 4);
        }

        //Serijalizacija podataka
        public byte[] ToByteArray()
        {
        List<byte> byteList = new List<byte>();
        byteList.AddRange(BitConverter.GetBytes(packageId));
        byteList.AddRange(BitConverter.GetBytes(pathId));

        return byteList.ToArray();
        }
    }
}
