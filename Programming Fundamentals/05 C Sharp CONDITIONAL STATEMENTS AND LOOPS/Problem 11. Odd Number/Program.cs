using System;

namespace Problem_11._Odd_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int num = int.Parse(Console.ReadLine());
                if (num%2==0)
                {
                    Console.WriteLine("Please write an odd number.");
                }
                else
                {
                    Console.WriteLine($"The number is: {Math.Abs(num)}");
                    break;
                }
            } while (true);
        }
    }
}
