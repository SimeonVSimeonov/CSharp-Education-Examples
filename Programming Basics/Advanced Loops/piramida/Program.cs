using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piramida
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int currentNum = 1;
            int row = 1;
            int br = 0;
            while (currentNum<= n)
            {
                Console.Write(currentNum + " ");
                currentNum++;
                br++;
                if (br==row)
                {
                    row++;
                    br = 0;
                    Console.WriteLine();
                }

            }
            Console.WriteLine();
        }
    }
}
