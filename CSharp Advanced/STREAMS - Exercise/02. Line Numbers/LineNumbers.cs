using System;
using System.IO;

namespace _02._Line_Numbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            var fileTest = File.Open("..//..//..//..//files//text.txt", FileMode.Open);
            var destinationPath = "..//..//..//..//files//output.txt";

            using (StreamReader reader = new StreamReader(fileTest))
            {
                using (StreamWriter writer = new StreamWriter(destinationPath))
                {
                    var line = reader.ReadLine();
                    var counter = 1;
                    while (line != null)
                    {
                        writer.WriteLine($"Line {counter++}:{line}");
                        line = reader.ReadLine();
                    }
                }
            }

        }
    }
}
