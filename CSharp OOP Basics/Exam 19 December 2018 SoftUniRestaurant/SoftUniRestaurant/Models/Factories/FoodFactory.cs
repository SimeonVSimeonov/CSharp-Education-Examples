using SoftUniRestaurant.Models.Foods;
using SoftUniRestaurant.Models.Foods.Contracts;
using System;
using System.Linq;

namespace SoftUniRestaurant.Models.Factories
{
    public class FoodFactory
    {
        public IFood CreateFood(string type, string name, decimal price)
        {
            switch (type)
            {
                case "Dessert":
                    return new Dessert(name, price);
                case "Salad":
                    return new Salad(name, price);
                case "Soup":
                    return new Soup(name, price);
                case "MainCourse":
                    return new MainCourse(name, price);
            }

            return null;
        }

        //This Or --->

        /*
        public Food CreateFood(string type, string name, decimal price)
        {
            var foodType = this.GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => typeof(Food).IsAssignableFrom(x) && !x.IsAbstract && x.Name == type);

            if (foodType == null)
            {
                throw new InvalidOperationException("Invalid product type!");
            }

            try
            {
                var food = (Food)Activator.CreateInstance(foodType, name, price);
                return food;
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }
        */
    }
}
