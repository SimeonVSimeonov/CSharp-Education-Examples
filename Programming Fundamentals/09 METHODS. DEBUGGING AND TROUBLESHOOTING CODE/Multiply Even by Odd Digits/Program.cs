using System;

namespace Multiply_Even_by_Odd_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));

            GetSumOfEvenDigits(number);
            GetSumOfOddDigits(number);
            Console.WriteLine(GetMultipleOfEvensAndOdds(number));
        }

        private static int GetMultipleOfEvensAndOdds(int multiply)
        {
            var result = GetSumOfEvenDigits(multiply) * GetSumOfOddDigits(multiply);
            return result;
        }

        private static int GetSumOfOddDigits(int number)
        {
            int sum = 0;

            while (number>0)
            {
                int residue = number % 10;
                number /= 10;
                if (residue%2==1)
                {
                    sum += residue;
                }
            }
            return sum;
        }

        private static int GetSumOfEvenDigits(int number)
        {
            int sum = 0;

            while (number>0)
            {
                int residue = number % 10;
                number /= 10;
                if (residue%2==0)
                {
                    sum += residue;
                }
            }
            return sum;
        }
    }
}
