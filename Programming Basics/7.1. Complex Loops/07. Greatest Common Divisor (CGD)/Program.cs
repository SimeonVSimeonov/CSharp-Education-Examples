﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Greatest_Common_Divisor__CGD_
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            while (b!=0)
            {
                int oldB = b;
                b = a % b;
                a = oldB;
            }
            Console.WriteLine("GCD = {0}",a);
        }
    }
}
