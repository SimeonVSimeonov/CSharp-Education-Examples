using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_Price
{
    class Program
    {
        static void Main(string[] args)
        {
            int distance = int.Parse(Console.ReadLine());
            string dayOrNight = Console.ReadLine().ToLower();
            double price = 0;
            double taxiRate = 0;

            if (dayOrNight=="day")
            {
                taxiRate = 0.79;
            }
            else
            {
                taxiRate = 0.9;
            }
            if (distance<20)
            {
                price = 0.70 + distance * taxiRate;
            }
            else if (distance<100)
            {
                price = distance * 0.09;
            }
            else
            {
                price = distance * 0.06;
            }
            Console.WriteLine(price);

        }
    }
}
