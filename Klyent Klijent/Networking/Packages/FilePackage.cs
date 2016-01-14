using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klijent.Networking.Packages
{
    class FilePackage
    {
        public int packageId { get; set; }
        public string fileName { get; set; }
        public byte[] fileData { get; set; }

        public FilePackage(byte[] filedata, string filename)
        {
            packageId = 11;
            fileName = filename;
            fileData = filedata;
        }

        //Deserijalizacija podataka
        public FilePackage(byte[] data)
        {
            packageId = BitConverter.ToInt32(data, 0);
            int fileNameLength = BitConverter.ToInt32(data, 4);
            fileName = Encoding.UTF8.GetString(data, 8, fileNameLength);
            int fileDataLength = BitConverter.ToInt32(data, 8 + fileNameLength);
            fileData = new byte[fileDataLength];
            Buffer.BlockCopy(data, 12 + fileNameLength, fileData, 0, fileDataLength);
        }

        public byte[] ToByteArray()
        {
            List<byte> byteList = new List<byte>();
            byteList.AddRange(BitConverter.GetBytes(packageId));
            byteList.AddRange(BitConverter.GetBytes(fileName.Length));
            byteList.AddRange(Encoding.UTF8.GetBytes(fileName));
            byteList.AddRange(BitConverter.GetBytes(fileData.Length));
            byteList.AddRange(fileData);

            return byteList.ToArray();
        }
    }
}
