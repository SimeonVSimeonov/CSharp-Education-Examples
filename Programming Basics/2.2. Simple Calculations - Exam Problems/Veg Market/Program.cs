using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            double veg = double.Parse(Console.ReadLine());
            double frut = double.Parse(Console.ReadLine());
            int vegAll = int.Parse(Console.ReadLine());
            int frutAll = int.Parse(Console.ReadLine());

            double vegTotal = veg * vegAll;
            double frutTotal = frut * frutAll;

            Console.WriteLine((vegTotal+frutTotal)/1.94);

        }
    }
}
