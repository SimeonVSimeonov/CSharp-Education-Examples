using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = decimal.Parse(Console.ReadLine());
            var inCurency = Console.ReadLine().ToLower();
            var outCurency = Console.ReadLine().ToLower();
            decimal firstResult = 0.0m;
            decimal secondResult = 0.0m;

            if (inCurency=="bgn")
            {
                firstResult = 1;
            }
            else if (inCurency=="usd")
            {
                firstResult = 1.79549m;
            }
            else if (inCurency=="eur")
            {
                firstResult = 1.95583m;
            }
            else if (inCurency=="gbp")
            {
                firstResult = 2.53405m;
            }
            if (outCurency=="bgn")
            {
                secondResult = 1;
            }
            else if (outCurency=="usd")
            {
                secondResult = 1.79549m;
            }
            else if (outCurency=="eur")
            {
                secondResult = 1.95583m;
            }
            else if (outCurency=="gbp")
            {
                secondResult = 2.53405m;
            }
            decimal result = n * (firstResult / secondResult);
            Console.WriteLine(Math.Round(result,2));
        }
    }
}
