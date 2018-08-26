using System;

namespace _10._Cube_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            string parameter = Console.ReadLine();

            if (parameter == "face")
            {
                Console.WriteLine("{0:F2}", FindFaceDiagonals(side));
            }
            else if (parameter == "space")
            {
                Console.WriteLine("{0:F2}", FindSpaceDiagonals(side));
            }
            else if (parameter == "volume")
            {
                Console.WriteLine("{0:F2}", FindVolume(side));
            }
            else if (parameter == "area")
            {
                Console.WriteLine("{0:F2}", FindSurfaceArea(side));
            }
        }

        private static double FindSurfaceArea(double side)
        {
            double result = 6 * (side * side);
            return result;
        }

        private static double FindVolume(double side)
        {
            double result = side * side * side;
            return result;
        }

        private static double FindSpaceDiagonals(double side)
        {
            double result = Math.Sqrt(3 * (side * side));
            return result;
        }

        private static double FindFaceDiagonals(double side)
        {
            double result = Math.Sqrt(2 * (side * side));
            return result;
        }
    }
}
