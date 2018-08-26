using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("n = ");
            int n = int.Parse(Console.ReadLine());
            int oddSum = 0;
            int evenSum = 0;

            for (int i = 0; i < n; i++)
            {
                int element = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += element;
                }
                else
                {
                    oddSum += element;
                }
            }
            if (oddSum==evenSum)
            {
                Console.WriteLine("Yes, sum = "+oddSum);
            }
            else
            {
                Console.WriteLine("No, diff = {0}",Math.Abs(oddSum-evenSum));
            }
        }
    }
}
