using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhombus_of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n-row; col++)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
                for (int col = 0; col < row; col++)
                {
                    Console.Write(" *");
                }
                Console.WriteLine();
            }
            for (int row = 0-1; row > 0; row--)
            {
                for (int col = 0; col < n - row; col++)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
                for (int col = 0; col < row; col++)
                {
                    Console.Write(" *");
                }
                Console.WriteLine();
            }
        }
    }
}
