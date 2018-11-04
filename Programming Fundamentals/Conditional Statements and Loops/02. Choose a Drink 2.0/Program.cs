using System;

namespace _02._Choose_a_Drink_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var count = int.Parse(Console.ReadLine());

            switch (input)
            {
                case "Athlete":
                    Console.WriteLine($"The {input} has to pay {count*0.70:F2}.");
                    break;
                case "Businessman":
                    Console.WriteLine($"The {input} has to pay {count * 1.00:F2}.");
                    break;
                case "Businesswoman":
                    Console.WriteLine($"The {input} has to pay {count * 1.00:F2}.");
                    break;
                case "SoftUni Student":
                    Console.WriteLine($"The {input} has to pay {count * 1.70:F2}.");
                    break;
                default:
                    Console.WriteLine($"The {input} has to pay {count * 1.20:F2}.");
                    break;
            }
        }
    }
}
