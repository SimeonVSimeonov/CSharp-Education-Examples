﻿using System;
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
            var n = int.Parse(Console.ReadLine());
            var evenSum = 0;
            var oddSum = 0;
            for (int i = 0; i < n; i++)
            {
                var number = int.Parse(Console.ReadLine());
                if (i % 2==0)
                {
                    evenSum += number;
                }
                else
                {
                    oddSum += number;
                }
            }
            if (evenSum==oddSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = "+evenSum);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("Diff = "+ Math.Abs(evenSum-oddSum));
            }
        }
    }
}
