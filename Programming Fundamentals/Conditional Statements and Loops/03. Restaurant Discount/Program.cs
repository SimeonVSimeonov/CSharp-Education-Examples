using System;

namespace _03._Restaurant_Discount
{
    class Program
    {
        static void Main(string[] args)
        {
            int group = int.Parse(Console.ReadLine());
            string package = Console.ReadLine();
            var hallName = "";
            var hallPrice = 0.0;
            var packPrice = 0.0;
            var discount = 0.0;
            var price = 0.0;

            if (group <= 50)
            {
                hallName = "Small Hall";
                hallPrice = 2500;

                if (package == "Normal")
                {
                    packPrice = 500;
                    discount = 0.95;
                    price = (hallPrice + packPrice) * discount / group;

                }
                else if (package == "Gold")
                {
                    packPrice = 750;
                    discount = 0.90;
                    price = (hallPrice + packPrice) * discount / group;

                }
                else if (package == "Platinum")
                {
                    packPrice = 1000;
                    discount = 0.85;
                    price = (hallPrice + packPrice) * discount / group;

                }

                Console.WriteLine($"We can offer you the {hallName}");
                Console.WriteLine($"The price per person is {price:F2}$");
            }
            else if (group <= 100)
            {
                hallName = "Terrace";
                hallPrice = 5000;

                if (package == "Normal")
                {
                    packPrice = 500;
                    discount = 0.95;
                    price = (hallPrice + packPrice) * discount / group;

                }
                else if (package == "Gold")
                {
                    packPrice = 750;
                    discount = 0.90;
                    price = (hallPrice + packPrice) * discount / group;

                }
                else if (package == "Platinum")
                {
                    packPrice = 1000;
                    discount = 0.85;
                    price = (hallPrice + packPrice) * discount / group;

                }

                Console.WriteLine($"We can offer you the {hallName}");
                Console.WriteLine($"The price per person is {price:F2}$");
            }
            else if (group <= 120)
            {
                hallName = "Great Hall";
                hallPrice = 7500;

                if (package == "Normal")
                {
                    packPrice = 500;
                    discount = 0.95;
                    price = (hallPrice + packPrice) * discount / group;

                }
                else if (package == "Gold")
                {
                    packPrice = 750;
                    discount = 0.90;
                    price = (hallPrice + packPrice) * discount / group;

                }
                else if (package == "Platinum")
                {
                    packPrice = 1000;
                    discount = 0.85;
                    price = (hallPrice + packPrice) * discount / group;

                }

                Console.WriteLine($"We can offer you the {hallName}");
                Console.WriteLine($"The price per person is {price:F2}$");
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
            }
        }
    }
}
