using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_converter
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal num = decimal.Parse(Console.ReadLine());
            string firstCurrency = Console.ReadLine();
            string secondCurrency = Console.ReadLine();
            decimal firstValue = 0.0m;
            decimal secondValue = 0.0m;
            if (firstCurrency == "BGN")
            {
                firstValue = 1;
            }
            else if (firstCurrency == "USD")
            {
                firstValue = 1.79549m;
            }
            else if (firstCurrency == "EUR")
            {
                firstValue = 1.95583m;
            }
            else if (firstCurrency == "GBP")
            {
                firstValue = 2.53405m;
            }
            if (secondCurrency == "BGN")
            {
                secondValue = 1;
            }
            else if (secondCurrency == "USD")
            {
                secondValue = 1.79549m;
            }
            else if (secondCurrency == "EUR")
            {
                secondValue = 1.95583m;
            }
            else if (secondCurrency == "GBP")
            {
                secondValue = 2.53405m;
            }
            decimal result = num * (firstValue / secondValue);
            Console.WriteLine(Math.Round(result, 2));
        }
    }
}
