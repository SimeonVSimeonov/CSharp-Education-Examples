using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_To_The_Past
{
    class Program
    {
        static void Main(string[] args)
        {
            double heritage = double.Parse(Console.ReadLine());
            int yearsToLive = int.Parse(Console.ReadLine());
            int years = 18;

            for (int currentYear = 1800; currentYear <= yearsToLive; currentYear++)
            {
                if (currentYear%2==0)
                {
                    heritage -= 12000;
                }
                else
                {
                    heritage -= (12000 + 50 * years);
                }
                years++;
            }
            if (heritage>=0)
            {
                Console.WriteLine("Yes! He will live a carefree life and will have {0:f2} dollars left.",heritage);
            }
            else
            {
                Console.WriteLine("He will need {0:f2} dollars to survive.", Math.Abs(heritage));
            }
        }
    }
}
