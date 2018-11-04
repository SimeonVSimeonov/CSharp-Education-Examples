using System;

namespace _04._Variable_in_Hex_Format
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
             Console.WriteLine(Convert.ToInt32(number,16));
        }
    }
}
