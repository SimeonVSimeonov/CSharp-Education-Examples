using System;
using System.Linq;

namespace _02._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            var pokeDistances = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var sum = 0;
            var index = 0;
            var current = 0;

            while (pokeDistances.Count>0)
            {
                index = int.Parse(Console.ReadLine());

                if (index<0)
                {
                    current = pokeDistances[0];
                    pokeDistances[0] = pokeDistances[pokeDistances.Count - 1];
                }
                else if (index>pokeDistances.Count-1)
                {
                    current = pokeDistances[pokeDistances.Count - 1];
                    pokeDistances[pokeDistances.Count - 1] = pokeDistances[0];
                }
                else
                {
                    current = pokeDistances[index];
                    pokeDistances.RemoveAt(index);
                    
                }

                sum += current;

                for (int i = 0; i < pokeDistances.Count; i++)
                {
                    if (pokeDistances[i]<=current)
                    {
                        pokeDistances[i] += current;
                    }
                    else
                    {
                        pokeDistances[i] -= current;
                    }
                }

                
            }

            Console.WriteLine(sum);
        }
    }
}
