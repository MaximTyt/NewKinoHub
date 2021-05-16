using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NewKinoHub.Manager
{
    public static class SaveImage
    {
        public static byte[] getByteImage(IFormFile file)
        {
            byte[] fileData = null;

            using (var binaryReader = new BinaryReader(file.OpenReadStream()))
            {
                fileData = binaryReader.ReadBytes((int)file.Length);
            }

            return fileData;
        }

        public static Image byteArrayToImage(byte[] bytesArr)
        {
            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }
    }
}
