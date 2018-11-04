using System;

namespace _12._Rectangle_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine(a * 2 + b * 2);
            Console.WriteLine(a * b);
            Console.WriteLine(Math.Sqrt(Math.Pow(a,2)+Math.Pow(b,2)));
        }
    }
}
