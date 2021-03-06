﻿using System;

namespace _12._Master_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                if (isPalindrome(i) && SumOfDigits(i) && ContainsEvenDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool ContainsEvenDigit(int num)
        {
            string n = num.ToString();
            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] % 2 == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool SumOfDigits(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += n % 10;
                n = n / 10;
            }
            if (sum % 7 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool isPalindrome(int num)
        {
            string sNum = num.ToString();
            for (int i = 0; i < sNum.Length; i++)
                if (sNum[i] != sNum[sNum.Length - 1 - i]) return false;
            return true;
        }
    }
}
