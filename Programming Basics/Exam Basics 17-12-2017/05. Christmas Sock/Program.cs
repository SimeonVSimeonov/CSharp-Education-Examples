using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Christmas_Sock
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.Write('|');
            Console.Write(new string(('-'), n * 2));
            Console.WriteLine('|');
            Console.Write('|');
            Console.Write(new string(('*'), n * 2));
            Console.WriteLine('|');
            Console.Write('|');
            Console.Write(new string(('-'), n * 2));
            Console.WriteLine('|');
            for (int i = 1; i <= n; i++)
            {
                Console.Write(new string('-', n - i));
                Console.Write("*");
                for (int k = 1; k <= i - 1; k++)
                {
                    Console.Write(" *");
                }
                Console.WriteLine(new string(('-'),n-i));
            }
            for (int i = n - 1; i > 0; i--)
            {
                Console.Write(new string('-', n - i));
                Console.Write("*");
                for (int k = 1; k <= i - 1; k++)
                {
                    Console.Write(" *");
                }
                Console.WriteLine(new string(('-'), n - i));
            }
        }
    }
}
