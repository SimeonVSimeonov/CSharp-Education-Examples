using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Key_Revolver
{
    class KeyRevolver
    {
        static void Main(string[] args)
        {
            Stack<int> loadedBullets = new Stack<int>();
            Queue<int> safe = new Queue<int>();
            int counter = 0;
            var bulletPrice = int.Parse(Console.ReadLine());
            var gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] locks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var intelligence = int.Parse(Console.ReadLine());

            foreach (var bullet in bullets)
            {
                loadedBullets.Push(bullet);
            }

            foreach (var item in locks)
            {
                safe.Enqueue(item);
            }

            /*  20 shoots lock 15(ping)
                10 shoots lock 15(bang)
                11 shoots lock13(bang)
                5 shoots lock 16(bang
                11 10 5 11 10 20
                15 13 16  */

            while (safe.Count > 0 && loadedBullets.Count > 0)
            {

                if (loadedBullets.Pop() <= safe.Peek())
                {
                    Console.WriteLine("Bang!");
                    safe.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                counter++;

                if (counter % gunBarrelSize == 0 && loadedBullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if (safe.Count==0)
            {
                var bulletsLeft = loadedBullets.Count;
                var moneyEarned = intelligence - (counter * bulletPrice);
                Console.WriteLine($"{bulletsLeft} bullets left. Earned ${moneyEarned}");
            }
            else
            {
                var locksLeft = safe.Count;
                Console.WriteLine($"Couldn't get through. Locks left: {locksLeft}");
            }
        }
    }
}
