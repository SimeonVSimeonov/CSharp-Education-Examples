using System;

namespace ConsoleApp1
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

            decimal headsetExpense = gamesCount / 2 * headsetPrice;
            decimal mouseExpense = gamesCount / 3 * mousePrice;
            decimal keyboardExpense = gamesCount / 6 * keyboardPrice;
            decimal displayExpense = gamesCount / 12 * displayPrice;
            decimal totalExpense = headsetExpense + mouseExpense + keyboardExpense + displayExpense;

            Console.WriteLine($"Rage expenses: {totalExpense:F2} lv.");
        }
    }
}
