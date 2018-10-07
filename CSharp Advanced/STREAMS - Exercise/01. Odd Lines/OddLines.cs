using System;
using System.IO;

namespace _01._Odd_Lines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            var fileTest = File.Open("..//..//..//..//files//text.txt", FileMode.Open);

            using (StreamReader stream = new StreamReader(fileTest))
            {
                var line = stream.ReadLine();
                int counter = 0;

                while (line != null)
                {
                    if (counter % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    counter++;
                    line = stream.ReadLine();
                }
            }

        }
    }
}
