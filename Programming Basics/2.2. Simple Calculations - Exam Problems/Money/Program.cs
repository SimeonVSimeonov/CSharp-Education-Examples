using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    class Program
    {
        static void Main(string[] args)
        {
            int bit = int.Parse(Console.ReadLine());
            double china = double.Parse(Console.ReadLine());
            double commis = double.Parse(Console.ReadLine())/100.00;

            double bitToLeva = bit * 1168;
            double chinaToDollar = china * 0.15;
            double dollarToLeva = chinaToDollar * 1.76;

            double All = bitToLeva + dollarToLeva;
            double euro = All / 1.95;
            euro -= commis * euro;
            Console.WriteLine(euro);
        }
    }
}
