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
            double full = r * c;
            double income = -1;

            switch (type)
            {
                case "premiere": income = full * 12.00; break;
                case "normal": income = full * 7.50; break;
                case "discount": income = full * 5.00; break;
            }
            Console.WriteLine("{0:f2}",income);
        }
    }
}
