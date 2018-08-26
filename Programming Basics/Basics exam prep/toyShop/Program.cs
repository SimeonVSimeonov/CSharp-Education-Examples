using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal jorPrice = decimal.Parse(Console.ReadLine());
            int bpuzzels = int.Parse(Console.ReadLine());
            int bKukli = int.Parse(Console.ReadLine());
            int bBears= int.Parse(Console.ReadLine());
            int bMin = int.Parse(Console.ReadLine());
            int bTrukc = int.Parse(Console.ReadLine());

            decimal income = bpuzzels * 2.6m + bKukli * 3 + bBears * 4.1m + bMin * 8.2m + bTrukc * 2;
            int tottalB = bpuzzels+bKukli+bBears+bMin+bTrukc;
            if (tottalB>=50)
            {
                income *= 0.75m;
            }
            income *= 0.9m;
            if (income>=jorPrice)
            {
                Console.WriteLine("Yes! {0:f2} lv left",income-jorPrice);
            }
            else
            {
                Console.WriteLine("No{0:0.00}",jorPrice-income);
            }
        }
    }
}
