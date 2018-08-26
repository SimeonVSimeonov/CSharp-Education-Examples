using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily_Earnings
{
    class Program
    {
        static void Main(string[] args)
        {
            int workDays = int.Parse(Console.ReadLine());
            decimal dayMoney = decimal.Parse(Console.ReadLine());
            decimal exchangeDollar = decimal.Parse(Console.ReadLine());

            decimal mountly = workDays * dayMoney;
            decimal year = mountly * 12 + mountly * 2.5m;
            decimal tax = year * 0.25m;
            decimal netMoney = year - tax;
            decimal average = (netMoney / 365) * exchangeDollar;
            Console.WriteLine("{0:f2}",average);
        }
    }
}
