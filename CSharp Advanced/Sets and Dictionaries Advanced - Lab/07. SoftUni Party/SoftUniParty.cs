using System;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class SoftUniParty
    {
        static void Main(string[] args)
        {
            var vip = new HashSet<string>();
            var regular = new HashSet<string>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "PARTY")
                {
                    break;
                }
                bool isDigit = char.IsDigit(input[0]);
                if (isDigit)
                {
                    vip.Add(input);
                    continue;
                }
                regular.Add(input);
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                if (vip.Contains(input))
                {
                    vip.Remove(input);
                }
                else if (regular.Contains(input))
                {
                    regular.Remove(input);
                } 
            }
            Console.WriteLine(vip.Count + regular.Count);
            foreach (var item in vip)
            {
                Console.WriteLine(item);
            }
            foreach (var item in regular)
            {
                Console.WriteLine(item);
            }
        }
    }
}
