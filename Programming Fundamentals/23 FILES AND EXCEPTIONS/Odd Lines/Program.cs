using System;
using System.IO;
using System.Linq;

namespace Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("lines.txt");
            var oddLines = lines.Where((line,index)=>index%2==1);
            File.WriteAllLines("odd-lines.txt", oddLines);

        }
    }
}
