﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace _06._Zipping_Sliced_Files
{
    class ZippingSlicedFiles
    {
        static List<string> paths;

        static void Main(string[] args)
        {
            paths = new List<string>();
            var sourceFile = "..//..//..//..//files//sliceme.mp4";
            var destination = "..//..//..//..//files//";
            int parts = 4;

            Slice(sourceFile, destination, parts);
            Assemble(paths, destination);
        }

        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream readFile = new FileStream(sourceFile, FileMode.Open))
            {
                long size = readFile.Length / parts + readFile.Length % parts;
                byte[] buffer = new byte[size];

                for (int i = 0; i < parts; i++)
                {
                    var destPath = destinationDirectory + $"Path{i}.mp4";
                    paths.Add(destPath);
                    int readedBytes = 0;
                    using (FileStream writeFile = new FileStream(destPath, FileMode.Create))
                    {
                        int bytesCount = readFile.Read(buffer, 0, buffer.Length);
                        writeFile.Write(buffer, 0, buffer.Length);
                    }
                    using (GZipStream gz = new GZipStream(new FileStream(destPath + ".gz", FileMode.Create),
                        CompressionMode.Compress, false))
                    {
                        gz.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            byte[] buffer = new byte[1024];
            destinationDirectory += "asembled.mp4";

            using (FileStream writeFile = new FileStream(destinationDirectory, FileMode.Create))
            {
                foreach (var path in paths)
                {
                    using (GZipStream gzZip = new GZipStream(new FileStream(path + ".gz", FileMode.Open),
                        CompressionMode.Decompress))
                    {
                        while (true)
                        {
                            int bytesCount = gzZip.Read(buffer, 0, buffer.Length);

                            if (bytesCount == 0)
                            {
                                break;
                            }

                            writeFile.Write(buffer, 0, bytesCount);
                        }
                    }
                }
            }
        }
    }
}
