using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            Double x1 = Double.Parse(Console.ReadLine());
            Double y1 = Double.Parse(Console.ReadLine());
            Double x2 = Double.Parse(Console.ReadLine());
            Double y2 = Double.Parse(Console.ReadLine());

            double width = Math.Max(x1, x2) - Math.Min(x1, x2);
            double height = Math.Max(y1, y2) - Math.Min(y1, y2);
            
            Console.WriteLine("{0}",width*height);
            Console.WriteLine("{0}",2*(width+height));
        }
    }
}
