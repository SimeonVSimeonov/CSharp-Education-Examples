using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int vineyardArea = int.Parse(Console.ReadLine());
            double grapePerSquare = double.Parse(Console.ReadLine());
            int needLiters = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double harvestPerVine = vineyardArea * grapePerSquare * 0.4;
            double vine = harvestPerVine / 2.5;

            if (vine<needLiters)
            {
                Console.WriteLine("It will be a tough winter! More {0} liters wine needed.",
                    Math.Floor(needLiters-vine));
            }
            else
            {
                Console.WriteLine("Good harvest this year! Total wine: {0} liters.",Math.Floor(vine));
                Console.WriteLine("{0} liters left -> {1} liters per person.",Math.Ceiling(vine-needLiters),
                    Math.Ceiling((vine-needLiters)/workers));
            }
        }
    }
}
