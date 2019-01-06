using System;
using System.Text.RegularExpressions;

namespace P03SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"\%(?<customer>[A-Z][a-z]+)\%[^|$%.]*\<(?<product>\w+)\>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+([.]\d+)?)\$";

            string input;
            double totalIncome = 0;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                
                if (Regex.IsMatch(input, pattern))
                {
                    Match match = Regex.Match(input, pattern);
                    var customer = match.Groups["customer"].Value;
                    var product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    double price = double.Parse(match.Groups["price"].Value);
                    double money = price * count;
                    Console.WriteLine($"{customer}: {product} - {money:F2}");
                    totalIncome += money;
                }
            }

            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}
