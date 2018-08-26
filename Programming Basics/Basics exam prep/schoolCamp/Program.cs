using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine().ToLower();
            string groupType = Console.ReadLine().ToLower();
            int studentCount = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            decimal price = 0;
            decimal costs = 0;
            string sportName = " ";


            if (season == "winter")
            {
                if (groupType == "mixed")
                {
                    price = 10;
                    sportName = "ski";
                }
                else
                {
                    price = 9.6m;
                    if (groupType=="boys")
                    {
                        sportName == "judo";
                    }
                    else
                    {
                        sportName == "gymnastic";
                    }
                }
            }
            else if (season == "spring")
            {
                if (groupType == "mixed")
                {
                    price = 9.5m;
                    sportName == "cycling";
                }
                else
                {
                    price = 7.2m;
                    price = 9.6m;
                    if (groupType == "boys")
                    {
                        sportName == "tennis";
                    }
                    else
                    {
                        sportName == "athletics";
                    }
                }
            }
            else if (season == "summer")
            {
                if (groupType == "mixed")
                {
                    price = 15;
                    sportName == "Swimming";
                }
                else
                {
                    price = 20m;
                    switch (groupType)
                    {
                        default:
                            break;
                    }
                }
            }
            costs = studentCount * days * price;
            if (studentCount>=50)
            {
                costs /= 2;
            }
            else if (studentCount>=20)
            {
                costs *= 0.85m;
            }
            else if (studentCount>=10)
            {
                costs *= 0.95m;
            }
            Console.WriteLine($"{sportName:f2} {costs:f2} lv.");
        }
    }
}
