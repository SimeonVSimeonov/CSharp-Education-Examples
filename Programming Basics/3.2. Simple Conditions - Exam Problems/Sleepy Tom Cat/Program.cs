using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleepy_Tom_Cat
{
    class Program
    {
        static void Main(string[] args)
        {
            int holidays = int.Parse(Console.ReadLine());

            int workdays = 365 - holidays;

            int playHolidays = holidays * 127;
            int playWorkday = workdays * 63;
            int allPlay = playHolidays + playWorkday;
            int playDiff = Math.Abs(allPlay - 30000);
            int hours = playDiff / 60;
            int min = playDiff % 60;
            if (allPlay>30000)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine("{0} hours and {1} minutes more for play", hours,min);
            }
            else
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine("{0} hours and {1} minutes less for play", hours,min);
            }


        }
    }
}
