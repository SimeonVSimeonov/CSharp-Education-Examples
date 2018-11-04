using System;
using System.Linq;

namespace _01._Largest_Common_End
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstString = Console.ReadLine().Split(' ').ToArray();
            string[] secondString = Console.ReadLine().Split(' ').ToArray();
            largestCommonEnd(firstString, secondString);
        }

        private static void largestCommonEnd(string[] firstString, string[] secondString)
        {
            int rightCount = 0;
            int leftCount = 0;
            while (rightCount < firstString.Length && rightCount < secondString.Length)
            {
                if (firstString[firstString.Length - rightCount - 1] == secondString[secondString.Length - rightCount - 1])
                {
                    rightCount++;
                }
                else break;
            }

            while (leftCount < firstString.Length && leftCount < secondString.Length)
            {
                if (firstString[leftCount] == secondString[leftCount])
                {
                    leftCount++;
                }
                else break;
            }

            if (rightCount > leftCount)
            {
                Console.WriteLine(rightCount);
            }
            else
            {
                Console.WriteLine(leftCount);
            }
        }
    }
}
