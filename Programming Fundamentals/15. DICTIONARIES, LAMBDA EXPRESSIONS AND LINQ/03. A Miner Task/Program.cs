using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mine = new Dictionary<string, int>();
            string comm = Console.ReadLine();
            string metal = "";
            int quantity = 0;
            while (comm !="stop")
            {
                metal = comm;
                quantity = int.Parse(Console.ReadLine());
                if (!mine.ContainsKey(metal))
                {
                    mine.Add(metal, quantity);
                }
                else
                {
                    mine[metal] += quantity;
                }
                comm = Console.ReadLine();
            }
            foreach (var pair in mine)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
