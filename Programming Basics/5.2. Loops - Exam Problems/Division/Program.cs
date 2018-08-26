using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNum = int.Parse(Console.ReadLine());

            double divisibleBy2 = 0;
            double divisibleBy3 = 0;
            double divisibleBy4 = 0;

            for (int num = 1; num <= countNum; num++)
            {
                int inNum = int.Parse(Console.ReadLine());

                if (inNum%2==0)
                {
                    divisibleBy2++;
                }
                if (inNum%3==0)
                {
                    divisibleBy3++;
                }
                if (inNum%4==0)
                {
                    divisibleBy4++;
                }
            }
            Console.WriteLine("{0:f2}%", divisibleBy2 / countNum * 100);
            Console.WriteLine("{0:f2}%", divisibleBy3 / countNum * 100);
            Console.WriteLine("{0:f2}%", divisibleBy4 / countNum * 100);
        }
    }
}
