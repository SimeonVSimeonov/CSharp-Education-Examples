using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumTab
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int currentNum = 1;
            int step = 1;

            for (int row = 0; row < n; row++)
            {
                currentNum = row + 1;
                step = 1;
                for (int col = 0; col < n; col++)
                {
                    if (col>0)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(currentNum);
                    if (currentNum>=n)
                    {
                        step = -1;
                    }
                    currentNum+=step;
                }
                Console.WriteLine();
            }
        }
    }
}
