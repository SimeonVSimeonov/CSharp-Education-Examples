using System;

namespace Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal moneyHas = decimal.Parse(Console.ReadLine());
            int countStud = int.Parse(Console.ReadLine());
            decimal lightsabersPrice = decimal.Parse(Console.ReadLine());
            decimal robesPrice = decimal.Parse(Console.ReadLine());
            decimal beltsPrice = decimal.Parse(Console.ReadLine());
            decimal freeBelts = countStud / 6;
            decimal neededMoney = 0.0m;

            neededMoney = (lightsabersPrice * Math.Ceiling(countStud * 1.1m)) + (robesPrice * countStud) + (beltsPrice * (countStud - freeBelts));
            if (moneyHas<neededMoney)
            {
                Console.WriteLine($"Ivan Cho will need {neededMoney-moneyHas:f2}lv more.");
            }
            else
            {
                Console.WriteLine($"The money is enough - it would cost {neededMoney:f2}lv.");

            }
        }
    }
}
