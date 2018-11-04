using System;

namespace _08._Calories_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var cheese = 500;
            var countCheese = 0;
            var tomatoSauce = 150;
            var countSauce = 0;
            var salami = 600;
            var countSalami = 0;
            var pepper = 50;
            var countPepper = 0;
            var totalCaloriesAmount = 0;

            for (int i = 0; i < n; i++)
            {
                var ingredients = Console.ReadLine().ToLower();
                if (ingredients == "cheese")
                {
                    countCheese++;
                }
                if (ingredients== "tomato sauce")
                {
                    countSauce++;
                }
                if (ingredients== "salami")
                {
                    countSalami++;
                }
                if (ingredients=="pepper")
                {
                    countPepper++;
                }

            }
            totalCaloriesAmount = cheese*countCheese + tomatoSauce*countSauce + salami*countSalami + pepper*countPepper;

            Console.WriteLine($"Total calories: {totalCaloriesAmount}");
        }
    }
}