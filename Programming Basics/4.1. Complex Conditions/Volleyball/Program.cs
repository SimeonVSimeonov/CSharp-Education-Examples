using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string yearType = Console.ReadLine();
            double p = int.Parse(Console.ReadLine());
            double h = int.Parse(Console.ReadLine());
            double weekends = 48;
            double weekendsSofia = (weekends - h) * 3 / 4;

            double gameHome = h;
            double gameSofia = p * 2 / 3;

            double all = weekendsSofia + gameHome + gameSofia;
            double ifYear = 0;

            if (yearType == "leap")
            {
                ifYear = (15 * all) / 100;
            }
            double final = Math.Truncate(ifYear + all);
            Console.WriteLine(final);
        }
    }
}
