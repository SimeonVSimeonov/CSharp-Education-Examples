using System;

namespace Power_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = double.Parse(Console.ReadLine());
            var power = double.Parse(Console.ReadLine());

            Console.WriteLine(PowerMetod(number, power));
        }

        static double PowerMetod(double number , double power)
        {
            double result = 1;
            for (int i = 0; i < power; i++)
            {
                result *= number;
            }
             return result;
        }
    }
}
