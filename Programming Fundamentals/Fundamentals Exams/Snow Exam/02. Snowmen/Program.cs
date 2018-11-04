using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Snowmen
{
    class Program
    {
        static void Main(string[] args)
        {
            var snowman = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (snowman.Count>1)
            {
               // var indexesToRemove = new List<int>();

                for (int i = 0; i < snowman.Count; i++)
                {
                    if(snowman.Count(x => x !=-1) == 1)
                    {
                        break;
                    }

                    if (snowman[i]==-1)
                    {
                        continue;
                    }


                    int attacker = i;
                    int target = snowman[i] % snowman.Count;

                    int diff = Math.Abs(attacker - target);

                    if (target==attacker)
                    {
                        // suicide
                        snowman[attacker] = -1;
                        Console.WriteLine($"{attacker} performed harakiri");
                       // indexesToRemove.Add(attacker);
                    }
                    else if (diff%2==0)
                    {
                        // attacker wins
                        snowman[target] = -1;
                        Console.WriteLine($"{attacker} x {target} -> {attacker} wins");
                       // indexesToRemove.Add(target);
                    }
                    else
                    {
                        // target wins
                        snowman[attacker] = -1;
                        Console.WriteLine($"{attacker} x {target} -> {target} wins");
                       // indexesToRemove.Add(attacker);
                    }
                }

                snowman = snowman
                    .Where(x => x != -1)
                    .ToList();
            }
        }
    }
}
