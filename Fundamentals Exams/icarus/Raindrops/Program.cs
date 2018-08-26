using System;
using System.Linq;

namespace Raindrops
{
    class Program
    {
        static void Main(string[] args)
        {
            int regionsAmount = int.Parse(Console.ReadLine());
            double density = double.Parse(Console.ReadLine());
            double sumRegional = 0;
            for (int i = 0; i < regionsAmount; i++)
            {
                string[] informationRegions = Console.ReadLine().Split();
                long raindropsCount = long.Parse(informationRegions[0]);
                int squareMeters = int.Parse(informationRegions[1]);

                double regionalCoefficient = (double)raindropsCount / squareMeters;
                sumRegional += regionalCoefficient;
            }

            if (density!=0)
            {
                Console.WriteLine($"{sumRegional / density:f3}");

            }
            else
            {
                Console.WriteLine($"{sumRegional:f3}");
            }
        }
    }
}
