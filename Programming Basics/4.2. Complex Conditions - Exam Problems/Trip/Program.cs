using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();

            string destinationResult = string.Empty;
            string hollydayType = string.Empty;
            decimal moneySpent = 0.00m;

            if (budget <= 100.00m)
            {
                destinationResult = "Bulgaria";
                if (season == "summer")
                {
                    moneySpent = 0.3m * budget;
                    hollydayType = "Camp";
                }
                else
                {
                    moneySpent = 0.7m * budget;
                    hollydayType = "Hotel";
                }

            }
            else if (budget <= 1000.00m)
            {
                destinationResult = "Balkans";
                if (season == "summer")
                {
                    moneySpent = 0.4m * budget;
                    hollydayType = "Camp";
                }
                else
                {
                    moneySpent = 0.8m * budget;
                    hollydayType = "Hotel";
                }
            }
            else
            {
                destinationResult = "Europe";
                hollydayType = "Hotel";
                moneySpent = 0.9m * budget;
            }
            Console.WriteLine("Somewhere in {0}",destinationResult);
            Console.WriteLine("{0} - {1:0.00}",hollydayType,moneySpent);
        }
    }
}


