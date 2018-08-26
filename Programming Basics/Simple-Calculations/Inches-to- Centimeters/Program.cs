using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inches_to__Centimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inches = ");
            double i = double.Parse(Console.ReadLine());
            double cm = i * 2.54;
            Console.Write("Centimeters = ");
            Console.WriteLine(cm);
         }
    }
}
