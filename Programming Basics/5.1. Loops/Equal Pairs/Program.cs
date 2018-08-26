using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPairs = int.Parse(Console.ReadLine());
            int currentSum = 0;
            int previousSum = 0;
            int diff = 0;

            for (int i = 0; i < numPairs; i++)
            {
                if (i==0)
                {
                    int firstNum = int.Parse(Console.ReadLine());
                    int secondNum = int.Parse(Console.ReadLine());
                    previousSum = firstNum + secondNum;
                }
                else
                {
                    int firstNum2 = int.Parse(Console.ReadLine());
                    int secondNum2 = int.Parse(Console.ReadLine());
                    currentSum = firstNum2 + secondNum2;
                    if ((Math.Abs(currentSum - previousSum))>diff)
                    {
                        diff = Math.Abs(currentSum - previousSum);
                    }
                    previousSum = currentSum;
                }
            }
            if (diff > 0)
            {
                Console.WriteLine("No, maxdiff=" + diff);
            }
            else
            {
                Console.WriteLine("Yes, value=" + previousSum);
            }
        }
    }
}
