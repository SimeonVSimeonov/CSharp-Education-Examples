using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Sunglasses
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.Write(new string('*', n * 2));
            Console.Write (new string(' ',n));
            Console.WriteLine(new string('*', n * 2));

            for (int i = 0; i < n-2; i++)
            {
                Console.Write('*');
                Console.Write(new string('/', n * 2 - 2));
                Console.Write('*');
                if (i==(n-3)/2)
                {
                    Console.Write(new string('|', n));
                }
                else
                {
                    Console.Write(new string(' ', n));
                }
                
                Console.Write('*');
                Console.Write(new string('/', n * 2 - 2));
                Console.WriteLine('*');
            }
            Console.Write(new string('*', n * 2));
            Console.Write(new string(' ', n));
            Console.WriteLine(new string('*', n * 2));

        }
    }
}
