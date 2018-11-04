using System;

namespace Problem_4._Beverage_Labels
{
    class Program
    {
        static void Main(string[] args)
        {
            string beverage = Console.ReadLine();
            int volume = int.Parse(Console.ReadLine());
            int energy = int.Parse(Console.ReadLine());
            int sugar = int.Parse(Console.ReadLine());
            double allEnergy = (double)volume * energy / 100;
            double allSugar = (double)volume * sugar / 100;
            Console.WriteLine($"{volume}ml {beverage}:\r\n{allEnergy}kcal, {allSugar}g sugars");
        }
    }
}
