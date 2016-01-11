using System;
using System.Collections.Generic;
using System.Text;

namespace Klijent.Networking.Packages
{
    class ClientInfoPackage
    {
        public int packageId { get; set; }
        public string clientComputerName {get; set;}
        public string clientOsVersion { get; set; }

        public ClientInfoPackage(string clientcomputername, string clientosversion)
        {
            packageId = 1;
            clientComputerName = clientcomputername;
            clientOsVersion = clientosversion;
        }

        //Deserijalizacija podataka
        public ClientInfoPackage(byte[] data)
        {
            packageId = BitConverter.ToInt32(data, 0);
            int clientComputerNameLength = BitConverter.ToInt32(data, 4);
            clientComputerName = Encoding.ASCII.GetString(data, 8, clientComputerNameLength);

            int clientOsVersionLength = BitConverter.ToInt32(data, 8 + clientComputerNameLength);
            clientOsVersion = Encoding.ASCII.GetString(data, 12 + clientComputerNameLength, clientOsVersionLength);
        }

        //Serijalizacija podataka
        public byte[] ToByteArray()
        {
            List<byte> byteList = new List<byte>();
            byteList.AddRange(BitConverter.GetBytes(packageId));
            byteList.AddRange(BitConverter.GetBytes(clientComputerName.Length));
            byteList.AddRange(Encoding.ASCII.GetBytes(clientComputerName));
            byteList.AddRange(BitConverter.GetBytes(clientOsVersion.Length));
            byteList.AddRange(Encoding.ASCII.GetBytes(clientOsVersion));

            return byteList.ToArray();
        }

    }
}
