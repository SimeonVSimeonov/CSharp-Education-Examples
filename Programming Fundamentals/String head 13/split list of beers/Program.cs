using System;

namespace split_list_of_beers
{
    class Program
    {
        static void Main(string[] args)
        {
            //first ex
            string listOfBeers = "Amstel, Zagorka, Tuborg, Becks";
            char[] separators = new char[] { ' ', ',', '.' };
            string[] beersArr = listOfBeers.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var beer in beersArr)
            {
                Console.WriteLine(beer);
            }

            //second ex
            string fileData = "   111 $  %    Ivan Ivanov  ### s   ";

            char[] trimChars = new char[] { ' ', '1', '$', '%', '#', 's' };

            string reduced = fileData.Trim(trimChars);
            Console.WriteLine(reduced);
        }
    }
}
