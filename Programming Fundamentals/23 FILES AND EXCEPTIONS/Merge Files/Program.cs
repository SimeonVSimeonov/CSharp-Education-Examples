using System;
using System.IO;
using System.Linq;

namespace Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] allData = File.ReadAllLines("TextFile1.txt");
            allData = allData.Concat(File.ReadAllLines("TextFile2.txt")).ToArray();
            File.WriteAllLines("output.txt", allData.OrderBy(x=>x));
        }
    }
}
