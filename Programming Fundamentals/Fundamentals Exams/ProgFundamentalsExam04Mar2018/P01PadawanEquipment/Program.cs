using System;

namespace P01PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            var amountMoney = decimal.Parse(Console.ReadLine());
            var countStudents = int.Parse(Console.ReadLine());
            var priceLightsabers = decimal.Parse(Console.ReadLine());
            var priceRobes = decimal.Parse(Console.ReadLine());
            var priceBelts = decimal.Parse(Console.ReadLine());

            decimal neededMoney = 0.0m;

            neededMoney = priceLightsabers * Math.Ceiling(countStudents * 1.1m) + priceRobes * (countStudents)
                + priceBelts * (countStudents - (countStudents / 6));

            if (neededMoney <= amountMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {neededMoney:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {neededMoney-amountMoney:F2}lv more.");
            }

        }
    }
}
