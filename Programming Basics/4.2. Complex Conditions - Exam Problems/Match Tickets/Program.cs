using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            string ticketType = Console.ReadLine().ToLower();
            int people = int.Parse(Console.ReadLine());

            decimal transportCharges = 0.00m;
            decimal moneyForTickets = 0.00m;
            decimal moneyDifference = 0.00m;

            if (people<=4)
            {
                transportCharges = 0.75m * budget;
            }
            else if (people<=9)
            {
                transportCharges = 0.60m * budget;
            }
            else if (people<=24)
            {
                transportCharges = 0.50m * budget;
            }
            else if (people<=49)
            {
                transportCharges = 0.40m * budget;
            }
            else if (people>=50)
            {
                transportCharges = 0.25m * budget;
            }
            switch (ticketType)
            {
                case "normal" :
                    moneyForTickets = people * 249.99m;break;
                case "vip":
                    moneyForTickets = people * 499.99m; break;
                default:
                    moneyForTickets = people * 249.99m;break;

            }
            moneyDifference = budget - transportCharges - moneyForTickets;
            string result = string.Format("Yes! You have {0} leva left.", decimal.Round(moneyDifference, 2));
            if (moneyDifference<0)
            {
                result = string.Format("Not enough money! You need {0} leva.", Math.Abs(decimal.Round(moneyDifference, 2)));
            }
            Console.WriteLine(result);

        }
    }
}
