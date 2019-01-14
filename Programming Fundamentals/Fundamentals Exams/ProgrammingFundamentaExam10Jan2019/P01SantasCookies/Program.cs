using System;

namespace P01SantasCookies
{
    class Program
    {
        static void Main(string[] args)
        {

            var batches = int.Parse(Console.ReadLine());

            var singleCookieGrams = 25;
            var cup = 140;
            var smallSpoon = 10;
            var bigSpoon = 20;
            var cookiesperBox = 5;

            var flourCups = 0;
            var sugarSpoons = 0;
            var cocoaSpoons = 0;
            var boxesPerBatch = 0;
            var totalCookiesPerBake = 0;
            var totalBoxes = 0;

            for (int i = 0; i < batches; i++)
            {
                
                var flourGrams = int.Parse(Console.ReadLine());
                var sugarGrams = int.Parse(Console.ReadLine());
                var cоcоаGrams = int.Parse(Console.ReadLine());

                flourCups = flourGrams / cup;
                sugarSpoons = sugarGrams / bigSpoon;
                cocoaSpoons = cоcоаGrams / smallSpoon;


                totalCookiesPerBake = (cup + smallSpoon + bigSpoon) * Math.Min(flourCups,Math.Min( sugarSpoons, cocoaSpoons)) / singleCookieGrams;
                

                if (totalCookiesPerBake <= cookiesperBox)
                {
                    Console.WriteLine("Ingredients are not enough for a box of cookies.");
                }
                boxesPerBatch = totalCookiesPerBake / cookiesperBox;
                if (totalCookiesPerBake>cookiesperBox)
                {
                    Console.WriteLine($"Boxes of cookies: {boxesPerBatch}");
                }
                totalBoxes += boxesPerBatch;
            }

            Console.WriteLine($"Total boxes: {totalBoxes}");
        }
    }
}
