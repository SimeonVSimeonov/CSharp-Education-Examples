using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.House
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var stars = 1;
            if (n   %2==0)
            {
                stars++;
            }
            var roofLeight = (int)Math.Ceiling(n / 2f);
            for (int i = 0; i < roofLeight; i++)
            {
                var padding = (n - stars) / 2;
                var line = new string('-', padding) + new string('*', stars) + new string('-', padding);
                Console.WriteLine(line);
                stars += 2;
            }
            for (int i = 0; i < n/2; i++)
            {
                Console.Write('|');
                Console.Write(new string('*', n - 2));
                Console.WriteLine('|');
            }
        }
    }
}
