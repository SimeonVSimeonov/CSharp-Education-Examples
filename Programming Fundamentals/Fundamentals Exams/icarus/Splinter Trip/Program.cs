using System;

namespace Splinter_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripDistance = double.Parse(Console.ReadLine());
            double fuelTankCapacity = double.Parse(Console.ReadLine());
            double milesHeavyWinds = double.Parse(Console.ReadLine());
            int consumes = 25;

            double nonHeavyWindsMiles = tripDistance - milesHeavyWinds;
            double nonHeavyWindsConsumption = nonHeavyWindsMiles * consumes;
            double heavyWindsConsumption = milesHeavyWinds*(consumes * 1.5);
            double fuelConsumption = heavyWindsConsumption + nonHeavyWindsConsumption;
            double totalFuelNeeded = fuelConsumption * 1.05;
            
            double remainingFuel = fuelTankCapacity - totalFuelNeeded;


            Console.WriteLine($"Fuel needed: {totalFuelNeeded:F2}L");

            if (fuelTankCapacity>=totalFuelNeeded)
            {
                Console.WriteLine($"Enough with {remainingFuel:F2}L to spare!");
            }
            else
            {
                Console.WriteLine($"We need {Math.Abs(remainingFuel):F2}L more fuel.");
            }
        }
    }
}
