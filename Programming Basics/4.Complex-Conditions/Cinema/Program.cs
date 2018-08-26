using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine().ToLower();
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            var price = 0.0;
            if (type=="premiere")
            {
                price = r * c * 12;
            }
            else if (type== "normal")
            {
                price = r * c * 7.50;
            }
            else if (type=="discount")
            {
                price = r * c * 5;
            }
            Console.WriteLine("{0:f2}",price);
        }
    }
}
