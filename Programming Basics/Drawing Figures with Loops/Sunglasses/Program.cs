using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunglasses
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());

            for (int row = 0; row < input; row++)
            {
                if (row == 0 || row == input - 1)
                {
                    for (int star = 0; star < input * 2; star++) Console.Write("*");
                    for (int space = 0; space < input; space++) Console.Write(" ");
                    for (int star = 0; star < input * 2; star++) Console.Write("*");
                    Console.WriteLine();
                }
                else if ((input % 2 != 0) && (row == input / 2) || (input % 2 == 0) && (row == input / 2 - 1))
                {
                    Console.Write("*");
                    for (int star = 0; star < input * 2 - 2; star++) Console.Write("/");
                    Console.Write("*");
                    for (int space = 0; space < input; space++) Console.Write("|");
                    Console.Write("*");
                    for (int star = 0; star < input * 2 - 2; star++) Console.Write("/");
                    Console.Write("*");
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("*");
                    for (int star = 0; star < input * 2 - 2; star++) Console.Write("/");
                    Console.Write("*");
                    for (int space = 0; space < input; space++) Console.Write(" ");
                    Console.Write("*");
                    for (int star = 0; star < input * 2 - 2; star++) Console.Write("/");
                    Console.Write("*");
                    Console.WriteLine();
                }
            }
        }
    }
}
