using System;

namespace Problem_5._Character_Stats
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int healt = int.Parse(Console.ReadLine());
            int healtMax = int.Parse(Console.ReadLine());
            int energy = int.Parse(Console.ReadLine());
            int energyMax = int.Parse(Console.ReadLine());

            string currentHealt = "|" + new string('|', healt) + new string('.', healtMax - healt) + "|";
            string currentEnergy = "|" + new string('|', energy) + new string('.', energyMax - energy) + "|";

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Health: {currentHealt}");
            Console.WriteLine($"Energy: {currentEnergy}");
        }
    }
}
