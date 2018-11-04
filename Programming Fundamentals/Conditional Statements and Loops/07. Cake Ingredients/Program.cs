using System;

namespace _07._Cake_Ingredients
{
    class Program
    {
        static void Main(string[] args)
        {
            var ingredients = Console.ReadLine();
            var counter = 0;
            while (ingredients!="Bake!")
            {
                counter++;
                Console.WriteLine($"Adding ingredient {ingredients}.");
                ingredients = Console.ReadLine();
            }
            Console.WriteLine($"Preparing cake with {counter} ingredients.");
        }
    }
}
