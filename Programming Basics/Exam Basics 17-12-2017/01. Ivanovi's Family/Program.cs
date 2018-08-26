using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Ivanovi_s_Family
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double childPresPrice1 = double.Parse(Console.ReadLine());
            double childPresPrice2 = double.Parse(Console.ReadLine());
            double childPresPrice3 = double.Parse(Console.ReadLine());

            double sumGift = 0;
            double donation = 0;

            sumGift = childPresPrice1 + childPresPrice2 + childPresPrice3;
            donation =  (budget - sumGift) * 0.90;
            Console.WriteLine("{0:f2}",donation);

        }
    }
}
