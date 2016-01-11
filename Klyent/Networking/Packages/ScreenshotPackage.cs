using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Server.Networking.Packages
{
    class ScreenshotPackage
    {
        public int packageId { get; set; }
        public Image screenShot { get; set; }

        public ScreenshotPackage(Image screenshot)
        {
            packageId = 4;
            screenShot = screenshot;
        }

        //Deserijalizacija podataka
        public ScreenshotPackage(byte[] data)
        {
            packageId = BitConverter.ToInt32(data, 0);
            int screenShotLength = BitConverter.ToInt32(data, 4);
            byte[] imageBytes = new byte[screenShotLength];
            Buffer.BlockCopy(data, 8, imageBytes, 0, screenShotLength);
            screenShot = byteArrayToImage(imageBytes);
        }

        private Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
