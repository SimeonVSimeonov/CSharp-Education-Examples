using System;
using System.Collections.Generic;

namespace _07._Primes_in_Given_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());
            string numbers = string.Join(", ", GetPrimeNumbers(startNum, endNum).ToArray());
            Console.WriteLine(numbers);
        }

        private static List<int> GetPrimeNumbers(int startNum, int endNum)
        {
            var result = new List<int>();
            for (int i = startNum; i <= endNum; i++)
            {
                bool isPrime = true;
                if (i < 2) isPrime = false;

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}
