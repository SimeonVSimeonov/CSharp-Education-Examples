using System;

namespace _15._Fast_Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int toCheck = 2; toCheck <= number; toCheck++)
            {
                bool isPrime = true;
                for (int curent = 2; curent <= Math.Sqrt(toCheck); curent++)
                {
                    if (toCheck % curent == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{toCheck} -> {isPrime}");
            }

        }
    }
}
