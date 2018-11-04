using System;

namespace Calculate_Triangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine(CalcTriangleArea(width,height));
        }

        private static double CalcTriangleArea(double width, double height)
        {
            return width * height / 2;
        }
    }
}
