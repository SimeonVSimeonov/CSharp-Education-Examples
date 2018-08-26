using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_in_the_Figure
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = int.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            if ((x > 0 && x < 3 * h && y > 0 && y < h) || (x > h && x < 2 * h && y > h && y < 4 * h) || (y == h && x > h && x < 2 * h))
            {
                Console.WriteLine("inside");
            }
            else if ((x < 0 || x > 3 * h || y < 0 || y > h) && (x < h || x > 2 * h || y < h || y > 4 * h))
            {
                Console.WriteLine("outside");
            }
            else
                Console.WriteLine("border");
        }
    }
}
