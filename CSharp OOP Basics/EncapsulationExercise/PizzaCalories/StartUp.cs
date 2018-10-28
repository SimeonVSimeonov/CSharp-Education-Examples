using System;

namespace PizzaCalories
{
    class StartUp
    {
        static void Main(string[] args)
        {

            //Pizza Meatless
            //Dough Wholegrain Crispy 100
            //Topping Veggies 50
            //Topping Cheese 50
            //END


            try
            {
                var tokens = Console.ReadLine().Split();
                Pizza pizza = new Pizza(tokens[1]);
                tokens = Console.ReadLine().Split();
                pizza.Dough = new Dough(tokens[1], tokens[2], double.Parse(tokens[3]));

                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    tokens = input.Split();
                    var we = double.Parse(tokens[2]);
                    //pizza.Toppings.Add(new Topping(tokens[1] + " " + tokens[2]));
                }

            }
            catch (Exception)
            {

                throw;
            }









        }
    }
}
