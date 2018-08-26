using System;

namespace _01._Charity_Marathon
{
    class Program
    {
        static void Main(string[] args)
        {
            var maratonDays = long.Parse(Console.ReadLine());
            var numRunners = long.Parse(Console.ReadLine());
            var averageLaps = long.Parse(Console.ReadLine());
            var lenghtTrack = long.Parse(Console.ReadLine());
            var capacityTrack = long.Parse(Console.ReadLine());
            var moneyPerKm = double.Parse(Console.ReadLine());

            var maxRunners = capacityTrack * maratonDays;
            numRunners = Math.Min(maxRunners, numRunners);

            var totalMetersRun = numRunners * averageLaps * lenghtTrack;
            var totalKm = totalMetersRun / 1000;
            var donation = totalKm * moneyPerKm;

            Console.WriteLine($"Money raised: {donation:F2}");
        }
    }
}
