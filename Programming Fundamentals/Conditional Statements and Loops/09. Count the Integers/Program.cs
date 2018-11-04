using System;
using System.Linq;

namespace _09._Count_the_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int couter = 0;

            while (true)
            {
                var input = Console.ReadLine();
                int value;

                if (int.TryParse(input,out value))
                {
                    couter++;
                }
                else
                {
                    break;
                }
              
            }
            Console.WriteLine(couter);


            //    var input = Console.ReadLine();
            //    var counter = 0;
            //    while (input.All(char.IsDigit))
            //    {
            //        input = Console.ReadLine();
            //        counter++;
            //    }
            //    Console.WriteLine(counter);
        }

    }
}
