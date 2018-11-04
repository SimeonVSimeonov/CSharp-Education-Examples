using System;
using System.Linq;

namespace _11._Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arry = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int leftSum = 0;
            int rightSum = 0;
            bool sumEqual = false;

            for (int i = 0; i < arry.Length; i++)
            {
                for (int left = 0; left < i; left++)
                {
                    leftSum += arry[left];
                }
                for (int right = i+1; right < arry.Length; right++)
                {
                    rightSum += arry[right];
                }
                if (leftSum==rightSum)
                {
                    Console.WriteLine(i);
                    sumEqual = true;
                    break;
                }
                leftSum = 0;
                rightSum = 0;
            }
            if (!sumEqual)
            {
                Console.WriteLine("no");
            }

        }
    }
}
