using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Klijent.Networking.Packages
{
    class ScreenshotPackage
    {
        public int packageId { get; set; }
        public Image screenShot { get; set; }

        public ScreenshotPackage(Image screenshot)
        {
            packageId = 5;
            screenShot = screenshot;
        }

        //Serijalizacija podataka
        public byte[] ToByteArray()
        {
            List<byte> byteList = new List<byte>();
            byteList.AddRange(BitConverter.GetBytes(packageId));
            byte[] screenShotBytes = imageToByteArray(screenShot);
            byteList.AddRange(BitConverter.GetBytes(screenShotBytes.Length));
            byteList.AddRange(screenShotBytes);

            return byteList.ToArray();
        }

        private byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

    }
}
