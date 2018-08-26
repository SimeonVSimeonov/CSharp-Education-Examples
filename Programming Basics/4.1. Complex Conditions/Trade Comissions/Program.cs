using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_Comissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine().ToLower();
            double sell = Double.Parse(Console.ReadLine());
            double bonus = -1.0;
            if (town == "sofia")
            {
                if (sell >= 0 && sell <= 500) bonus = 0.05;
                else if (sell > 500 && sell <= 1000) bonus = 0.07;
                else if (sell > 1000 && sell <= 10000) bonus = 0.08;
                else if (sell > 10000) bonus = 0.12;
            }
            else if (town == "varna")
            {
                if (sell >= 0 && sell <= 500) bonus = 0.045;
                else if (sell > 500 && sell <= 1000) bonus = 0.075;
                else if (sell > 1000 && sell <= 10000) bonus = 0.1;
                else if (sell > 10000) bonus = 0.13;
            }
            else if (town == "plovdiv")
            {
                if (sell >= 0 && sell <= 500) bonus = 0.055;
                else if (sell > 500 && sell <= 1000) bonus = 0.08;
                else if (sell > 1000 && sell <= 10000) bonus = 0.12;
                else if (sell > 10000) bonus = 0.145;
            }
            if (bonus >= 0)
            {
                Console.WriteLine("{0:f2}", sell * bonus);
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
