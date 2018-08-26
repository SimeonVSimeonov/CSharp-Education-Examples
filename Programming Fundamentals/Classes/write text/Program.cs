using System;
using System.IO;

namespace write_text
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter writer = new StreamWriter("text.txt");

            using (writer)
            {
                for (int i = 1; i <= 20; i++)
                {
                    writer.WriteLine(i);
                }
            }
        }
    }
}
