using System;

namespace _11._Geometry_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string figureType = Console.ReadLine().ToLower();
            switch (figureType)
            {
                case "triangle":
                    double b = double.Parse(Console.ReadLine());
                    double h = double.Parse(Console.ReadLine());
                    Console.WriteLine("{0:f2}", PrintTriangleArea(b, h));
                    break;
                case "square":
                    double a = double.Parse(Console.ReadLine());
                    Console.WriteLine("{0:f2}", PrintSquareArea(a));
                    break;
                case "rectangle":
                    double w = double.Parse(Console.ReadLine());
                    double hRec = double.Parse(Console.ReadLine());
                    Console.WriteLine("{0:f2}", PrintRectangleArea(w, hRec));
                    break;
                case "circle":
                    double r = double.Parse(Console.ReadLine());
                    Console.WriteLine("{0:f2}", PrintCircleArea(r));
                    break;
            }
        }

        private static double PrintCircleArea(double r)
        {
            return Math.PI * r * r;
        }

        private static double PrintRectangleArea(double w, double hRec)
        {
            return w * hRec;
        }

        private static double PrintSquareArea(double a)
        {
            return a * a;
        }

        private static double PrintTriangleArea(double b, double h)
        {
            return (b * h) / 2;
        }
    }
}
