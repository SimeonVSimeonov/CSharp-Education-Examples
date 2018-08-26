using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odd_Even_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double oddSum = 0, evenSum = 0;
            double oddMin = 1000000000, oddMax = -1000000000;
            double evenMin = 1000000000, evenMax = -1000000000;
            for (int pos = 1; pos <= n; pos++)
            {
                double num = double.Parse(Console.ReadLine());
                if (pos%2==0)
                {
                    evenSum += num;
                    if (num>evenMax)
                    {
                        evenMax = num;
                    }
                    if (num<evenMin)
                    {
                        evenMin = num;
                    }
                }
                else
                {
                    oddSum += num;
                    if (num > oddMax)
                    {
                        oddMax = num;
                    }
                    if (num < oddMin)
                    {
                        oddMin = num;
                    }
                }
            }
            Console.WriteLine("OddSum=" + oddSum);
            if (oddMax==-1000000000 && oddMin==1000000000)
            {
                Console.WriteLine("OddMin=No");
                Console.WriteLine("OddMax=No");
            }
            else
            {
                Console.WriteLine("OddMin=" + oddMin);
                Console.WriteLine("OddMax=" + oddMax);
            }


            Console.WriteLine("EvenSum=" + evenSum);
            if (evenMax == -1000000000 && evenMin == 1000000000)
            {
                Console.WriteLine("EvenMin=No");
                Console.WriteLine("EvenMax=No");
            }
            else
            {
                Console.WriteLine("EvenMin=" + evenMin);
                Console.WriteLine("EvenMax=" + evenMax);
            }
        }
    }
}
 