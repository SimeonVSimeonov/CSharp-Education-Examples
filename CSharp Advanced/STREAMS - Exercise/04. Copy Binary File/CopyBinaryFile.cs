using System;
using System.IO;

namespace _04._Copy_Binary_File
{
    class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            var sourceFile = "../../../../files//copyMe.png";
            var destinationPath = "../../../../files//copyMe-copy.png";

            using (FileStream stream = new FileStream(sourceFile,FileMode.Open))
            {
                var size = stream.Length;

                byte[] buffer = new byte[size];
                stream.Read(buffer, 0, buffer.Length);

                using (FileStream writeFile = new FileStream(destinationPath,FileMode.Create))
                {
                    writeFile.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
