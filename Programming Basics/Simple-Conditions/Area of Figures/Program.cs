using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            if (figure== "square")
            {
                Double a = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round(a * a, 3));
            }
            else if (figure == "rectangle")
            {
                Double a = double.Parse(Console.ReadLine());
                Double b = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round(a * b, 3));
            }
            else if (figure == "circle")
            {
                Double r = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round(Math.PI*r*r, 3));
            }
            else if (figure == "triangle")
            {
                Double b = double.Parse(Console.ReadLine());
                Double h = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.Round(0.5*b*h, 3));
            }
        }
    }
}
