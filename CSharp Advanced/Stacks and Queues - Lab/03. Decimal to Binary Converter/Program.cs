using System;
using System.Collections.Generic;

namespace _03._Decimal_to_Binary_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            int decimalNum = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            if (decimalNum == 0)
            {
                Console.WriteLine(0);
                return;
            }

            while (decimalNum > 0)
            {
                stack.Push(decimalNum % 2);
                decimalNum /= 2;
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }
    }
}
