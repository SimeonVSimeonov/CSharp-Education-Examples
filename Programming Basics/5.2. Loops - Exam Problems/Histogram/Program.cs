using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double p1Percentage = 0;
            double p2Percentage = 0;
            double p3Percentage = 0;
            double p4Percentage = 0;
            double p5Percentage = 0;

            int cntP1 = 0;
            int cntP2 = 0;
            int cntP3 = 0;
            int cntP4 = 0;
            int cntP5 = 0;

            for (int i = 0; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                if (currentNum < 200)
                {
                    cntP1++;
                }
                else if (currentNum < 400)
                {
                    cntP2++;
                }
                else if (currentNum < 600)
                {
                    cntP3++;
                }
                else if (currentNum < 800)
                {
                    cntP4++;
                }
                else
                {
                    cntP5++;
                }
            }
            p1Percentage = cntP1 * 100.0 / n;
            p2Percentage = cntP2 * 100.0 / n;
            p3Percentage = cntP3 * 100.0 / n;
            p4Percentage = cntP4 * 100.0 / n;
            p5Percentage = cntP5 * 100.0 / n;

            Console.WriteLine("{0:f2}%", p1Percentage);
            Console.WriteLine("{0:f2}%", p2Percentage);
            Console.WriteLine("{0:f2}%", p3Percentage);
            Console.WriteLine("{0:f2}%", p4Percentage);
            Console.WriteLine("{0:f2}%", p5Percentage);
        }
    }
}
