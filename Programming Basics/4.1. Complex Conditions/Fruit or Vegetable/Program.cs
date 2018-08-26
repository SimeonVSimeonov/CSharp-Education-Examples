using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_or_Vegetable
{
    class Program
    {
        static void Main(string[] args)
        {
            string m = Console.ReadLine().ToLower();

            if (m == "banana"||m == "apple"||m == "kiwi"
                ||m == "cherry"||m == "lemon"||m == "grapes")
            {
                Console.WriteLine("fruit");
            }
            else if (m == "tomato"||m == "cucumber" || m == "pepper" || m == "carrot")
            {
                Console.WriteLine("vegetable");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
