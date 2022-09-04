using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Order_System.Helper
{
    public static class UploaderImagesHelper
    {

        public static void SaveByteArrayToFileWithStaticMethod(byte[] data, string filePath)
        {

            File.WriteAllBytes(filePath, data);

        }
    }
}
