using System;

namespace P01RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int gamesCount = int.Parse(Console.ReadLine());
            decimal headsetPrice = decimal.Parse(Console.ReadLine());
            decimal mousePrice = decimal.Parse(Console.ReadLine());
            decimal keyboardPrice = decimal.Parse(Console.ReadLine());
            decimal displayPrice = decimal.Parse(Console.ReadLine());
            var totalSum = 0.0m;

            for (int i = 1; i <= gamesCount; i++)
            {
                if (i%2==0)
                {
                    totalSum += headsetPrice;
                }
                if (i%3==0)
                {
                    totalSum += mousePrice;
                }
                if (i%6==0)
                {
                    totalSum += keyboardPrice;
                }
                if (i%12==0)
                {
                    totalSum += displayPrice;
                }
            }
            Console.WriteLine($"Rage expenses: {totalSum:F2} lv.");
        }
    }
}
