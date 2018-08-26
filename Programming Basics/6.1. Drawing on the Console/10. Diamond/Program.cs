using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Diamond
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int leftRight = (n - 1) / 2;
            int stars = 1;
            if (n % 2 == 0)
            {
                stars++;
            }
            for (int i = 0; i < (n-1)/2; i++)
            {
                Console.Write(new string('-', leftRight));
                Console.Write("*");
                int mid = n - 2 * leftRight - 2;
                if (mid >= 0)
                {
                    Console.Write(new string('-', mid));
                    Console.Write("*");
                }
                Console.WriteLine(new string('-', leftRight));
                leftRight--;
            }
            for (int i = 0; i < (n-1)/2; i++)
            {
                Console.Write(new string('-', leftRight));
                Console.Write("*");
                int mid = n - 2 * leftRight - 2;
                if (mid >= 0)
                {
                    Console.Write(new string('-', mid));
                    Console.Write("*");
                }
                Console.WriteLine(new string('-', leftRight));
                leftRight++;
            }
            Console.Write(new string('-', leftRight));
            Console.Write(new string('*', stars));
            Console.WriteLine(new string('-', leftRight));
        }
    }
}
