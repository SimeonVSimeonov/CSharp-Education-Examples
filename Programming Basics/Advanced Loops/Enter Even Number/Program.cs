using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enter_Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 0;
            while (true)
            {
                Console.Write("Enter even number: ");
                var m = int.Parse(Console.ReadLine());
                n=m;
                if (n % 2 == 0)
                    break;
                Console.WriteLine("The number is not even.");
            }
            Console.WriteLine("Even number entered: {0}", n);
        }
    }
}
