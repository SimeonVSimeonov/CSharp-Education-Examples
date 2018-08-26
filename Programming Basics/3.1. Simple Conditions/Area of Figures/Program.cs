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
            string figure = Console.ReadLine().ToLower();
            double result = 0;

            if (figure =="square")
            {
                double a = double.Parse(Console.ReadLine());
                result = a * a;
            }
            else if (figure == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                result = a * b;
            }
            else if (figure == "circle")
            {
                double a = double.Parse(Console.ReadLine());
                result = Math.PI * a * a;
            }
            else if (figure == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                result = a * b / 2;
            }
            Console.WriteLine(result);

        }
    }
}
