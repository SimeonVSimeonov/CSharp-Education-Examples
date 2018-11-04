using System;

namespace _14._Integer_to_Hex_and_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            string binary = Convert.ToString(input,2);
            string hexa = Convert.ToString(input, 16).ToUpper();

            Console.WriteLine(hexa);
            Console.WriteLine(binary);

        }
    }
}
