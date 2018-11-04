using System;

namespace _04._Hotel
{
    class Program
    {
        static void Main(string[] args)
        {

            var mounth = Console.ReadLine();
            var nightsCount = int.Parse(Console.ReadLine());

            decimal priceStudio = 0;
            decimal priceDouble = 0;
            decimal priceSuite = 0;

            if (mounth == "May" || mounth=="October")
            {
                 priceStudio = 50;
                 priceDouble = 65;
                 priceSuite = 75;
                
            }
            else if (mounth == "June" || mounth == "September")
            {

                 priceStudio = 60;
                 priceDouble = 72;
                 priceSuite = 82;
            }
            else if (mounth == "July" || mounth == "August" || mounth == "December")
            {

                 priceStudio = 68;
                 priceDouble = 77;
                 priceSuite = 89;
                
            }

            priceStudio *= nightsCount;
            priceDouble *= nightsCount;
            priceSuite *= nightsCount;

            if ((mounth == "May" || mounth == "October") && nightsCount > 7)
            {
                priceStudio *= 0.95m;
            }
            else if ((mounth == "June" || mounth == "September") && nightsCount > 14)
            {
                priceDouble *= 0.9m;
            }
            else if ((mounth == "July" || mounth == "August" || mounth == "December") && nightsCount > 14)
            {
                priceSuite *= 0.85m;
            }

            if ((mounth == "September" || mounth == "October") && nightsCount > 7)
            {
                priceStudio *= (1 - (1.0m / nightsCount));
            }

            Console.WriteLine($"Studio: {priceStudio:F2} lv. \r\nDouble: {priceDouble:F2} lv. \r\nSuite: {priceSuite:F2} lv.");
        }
    }
}
