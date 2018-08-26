using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classroom
{
    class Program
    {
        static void Main(string[] args)
        {
            double i = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double row = Math.Floor(i / 1.2);
            double colum =Math.Floor((w-1) / 0.7);
            Console.WriteLine(row*colum-3);



        }
    }
}
