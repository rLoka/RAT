using System;
using System.Collections.Generic;

namespace Server.Networking.Packages
{
    class RequestPackage
    {
        public int packageId { get; set; }

        public RequestPackage(int request)
        {
            packageId = request;
        }

        //Deserijalizacija podataka
        public RequestPackage(byte[] data)
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
