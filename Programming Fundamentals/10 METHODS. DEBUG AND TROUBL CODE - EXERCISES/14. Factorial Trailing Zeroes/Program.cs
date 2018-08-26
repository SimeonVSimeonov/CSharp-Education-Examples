using System;
using System.Numerics;

namespace _14._Factorial_Trailing_Zeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                int n = int.Parse(Console.ReadLine());
                BigInteger factorial = 1;
                for (int i = 1; i <= n; i++)
                {
                    factorial *= i;
                }
                GetTrailingZeroes(factorial);
            }
        }
        static void GetTrailingZeroes(BigInteger num)
        {

            BigInteger timesZero = 0;
            while (num % 10 == 0)
            {
                num = num / 10;
                timesZero++;
            }
            Console.WriteLine(timesZero);
        }
    }
}
