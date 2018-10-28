using System;

namespace _05._Date_Modifier
{
    class StartUp
    {

        static void Main(string[] args)
        {

            var dateOne = Console.ReadLine();
            var dateTwo = Console.ReadLine();

            DateModifier difference = new DateModifier();

            var result = difference.FindDifference(dateOne, dateTwo);
            Console.WriteLine(result);
        }

    }
}
