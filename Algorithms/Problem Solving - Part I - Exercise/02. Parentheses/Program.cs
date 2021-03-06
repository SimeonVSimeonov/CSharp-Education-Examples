﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _02._Parentheses
{
    class Program
    {
        static readonly StringBuilder result = new StringBuilder();
        static int n;
        static int openingCount;
        static int closingCount;
        static char[] output;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            output = new char[n * 2];
            output[0] = '(';
            openingCount++;

            GenerateParenthesis(1);
            Console.Write(result);
        }

        static void GenerateParenthesis(int index)
        {
            if (index == output.Length)
            {
                result.AppendLine(string.Join("", output));
                return;
            }

            if (openingCount < n)
            {
                output[index] = '(';
                openingCount++;
                GenerateParenthesis(index + 1);
                openingCount--;
            }

            if (closingCount < openingCount)
            {
                output[index] = ')';
                closingCount++;
                GenerateParenthesis(index + 1);
                closingCount--;
            }
        }
    }
}
