using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideA = double.Parse(Console.ReadLine());
            double rectangleDiagonal = (Math.Pow(sideA, 4));
            Console.WriteLine(rectangleDiagonal);
        }
    }
}
