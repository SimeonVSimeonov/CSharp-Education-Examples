﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var sum = 0;
            do
            {
                sum = sum + (n % 10);
                n = n / 10;
            } while (n>0);
            Console.WriteLine("Sum of digits: {0}", sum);
        }
    }
}
