using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Lilly
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double priceOfWashingMachine = double.Parse(Console.ReadLine());
            int presentPrice = int.Parse(Console.ReadLine());

            int numberOfToys = 0;
            int savedManey = 0;
            int moneyForBirthday = 10;

            for (int currentYear = 1; currentYear <= age; currentYear++)
            {
                if (currentYear%2==0)
                {
                    savedManey += moneyForBirthday - 1;
                    moneyForBirthday += 10;
                }
                else
                {
                    numberOfToys++;
                }
            }
            savedManey += numberOfToys * presentPrice;
            Console.WriteLine(savedManey>=priceOfWashingMachine? $"Yes! {(savedManey-priceOfWashingMachine):0.00}":
                $"No! {(priceOfWashingMachine - savedManey):0.00}");
        }
    }
}
