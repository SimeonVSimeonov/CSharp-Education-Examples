using System;

namespace Problem_5._Character_Stats_for_cycle
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

            Console.WriteLine($"Name: {name}");
            Console.Write("Health: |");
            for (int i = 0; i < healt; i++)
            {
                Console.Write("|");
            }
            for (int i = 0; i < healtMax-healt; i++)
            {
                Console.Write(".");
            }
            Console.WriteLine("|");
            Console.Write("Energy: |");
            for (int i = 0; i < energy; i++)
            {
                Console.Write("|");
            }
            for (int i = 0; i < energyMax-energy; i++)
            {
                Console.Write(".");
            }
            Console.WriteLine("|");
        }
    }
}
