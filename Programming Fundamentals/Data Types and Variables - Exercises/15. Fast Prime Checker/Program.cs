using System;

namespace _15._Fast_Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            for (int forCheck = 2; forCheck <= input; forCheck++)
            {
                bool isPrime = true;
                for (int curent = 2; curent <= Math.Sqrt(forCheck); curent++)
                {
                    if (forCheck % curent == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{forCheck} -> {isPrime}");
            }

        }
    }
}
