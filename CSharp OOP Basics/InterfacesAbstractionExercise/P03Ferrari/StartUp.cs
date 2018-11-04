using System;

namespace P03Ferrari
{
    public class StartUp
    {
        static void Main()
        {
            var driver = Console.ReadLine();
            Ferrari ferrari = new Ferrari("488-Spider", driver);

            Console.WriteLine(ferrari);

        }
    }
}
