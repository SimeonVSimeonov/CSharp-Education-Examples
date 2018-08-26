using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alcoholMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal priceWhiskey = decimal.Parse(Console.ReadLine());
            decimal qBeer = decimal.Parse(Console.ReadLine());
            decimal qWine = decimal.Parse(Console.ReadLine());
            decimal qRakiq = decimal.Parse(Console.ReadLine());
            decimal qWhiskey = decimal.Parse(Console.ReadLine());


            decimal priceRakiq = priceWhiskey / 2;
            decimal priceWine = priceRakiq * 0.6m;
            decimal priceBeer = priceRakiq * 0.2m;

            decimal price = priceBeer * qBeer + priceRakiq * qRakiq + priceWhiskey * qWhiskey + priceWine * qWine;
            Console.WriteLine("{0:f2}",price);
        }
    }
}
