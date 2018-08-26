﻿using System;

namespace Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintTriangle(n);
        }

        static void PrintTriangle(int n)
        {
            for (int line = 1; line <= n; line++)
                PrintLine(1, line);

            for (int line = n - 1; line >= 1; line--)
                PrintLine(1, line);
        }

        private static void PrintLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write("{0} ",i);
            }
            Console.WriteLine();
        }
    }
}
