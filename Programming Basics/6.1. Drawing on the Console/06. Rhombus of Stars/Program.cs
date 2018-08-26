using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Rhombus_of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.Write(new string(' ', n - i));
                Console.Write("*");
                for (int k = 1; k <= i - 1; k++)
                {
                    Console.Write(" *");
                }
                Console.WriteLine();
            }
            for (int i = n - 1; i > 0; i--)
            {
                Console.Write(new string(' ', n - i));
                Console.Write("*");
                for (int k = 1; k <= i - 1; k++)
                {
                    Console.Write(" *");
                }
                Console.WriteLine();
            }
        }
    }
}
