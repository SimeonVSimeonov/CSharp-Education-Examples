using System;

namespace _15._Neighbour_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            var peshoDamage = int.Parse(Console.ReadLine());
            var goshoDamage = int.Parse(Console.ReadLine());
            var peshoHealth = 100;
            var goshoHealth = 100;

            var round = 1;
            while (peshoHealth > 0 || goshoHealth > 0)
            {

                if (round % 2 == 0)
                {
                    peshoHealth -= goshoDamage;

                    if (peshoHealth <= 0)
                    {
                        Console.WriteLine($"Gosho won in {round}th round.");
                        return;
                    }
                    Console.WriteLine($"Gosho used Thunderous fist and reduced Pesho to {peshoHealth} health.");
                }
                else
                {
                    goshoHealth -= peshoDamage;

                    if (goshoHealth <= 0)
                    {
                        Console.WriteLine($"Pesho won in {round}th round.");
                        return;
                    }
                    Console.WriteLine($"Pesho used Roundhouse kick and reduced Gosho to {goshoHealth} health.");

                }
                if (round % 3 == 0)
                {
                    peshoHealth += 10;
                    goshoHealth += 10;

                }
                round++;

            }
        }
    }
}
