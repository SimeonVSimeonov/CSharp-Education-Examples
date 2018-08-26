using System;
using System.IO;

namespace reading_text
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("sample.txt");

            using(reader)
            {
                int lineNumber = 0;
                string line = reader.ReadLine();

                while (line != null)
                {
                    lineNumber++;
                    Console.WriteLine("Line {0}: {1}", lineNumber, line);
                    line = reader.ReadLine();
                }

            }
        }
    }
}
