using System;
using System.Linq;

namespace icarus
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int damage = 1;
            int position = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine().Split(' ').ToArray();
            while (command[0] != "Supernova")
            {
                int steps = int.Parse(command[1]);
                if (command[0] == "left")
                {
                    for (int i = 0; i < steps; i++)
                    {
                        if (position == 0)
                        {
                            position = sequence.Length - 1;
                            damage++;
                        }
                        else
                        {
                            position--;
                        }
                        sequence[position] -= damage;
                    }
                }
                else if (command[0] == "right")
                {
                    for (int i = 0; i < steps; i++)
                    {
                        if (position == sequence.Length - 1)
                        {
                            position = 0;
                            damage++;
                        }
                        else
                        {
                            position++;
                        }
                        sequence[position] -= damage;
                    }
                }
                command = Console.ReadLine().Split(' ').ToArray();
            }
            Console.WriteLine(string.Join(" ", sequence));

        }
    }
}
