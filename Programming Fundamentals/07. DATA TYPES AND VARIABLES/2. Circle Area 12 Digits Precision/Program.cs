using System;

namespace _2._Circle_Area_12_Digits_Precision
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());

            var circleArea = Math.PI * Math.Pow(r, 2);
            Console.WriteLine($"{circleArea:f12}");
        }
    }
}
