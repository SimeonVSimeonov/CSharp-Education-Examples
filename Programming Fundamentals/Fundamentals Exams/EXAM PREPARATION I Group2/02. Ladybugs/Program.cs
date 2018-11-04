using System;
using System.Linq;

namespace _02._Ladybugs
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            var field = new int [size];

            var ladybugindex = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(i => i >= 0 && i < size)
                .ToList();

            foreach (var index in ladybugindex)
            {
                field[index] = 1; // ladybug here
            }

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                var commandParts = line.Split(' '); // 1 left 5

                var currentladybugIndex = int.Parse(commandParts[0]);
                var direction = commandParts[1];
                var flyLenght = int.Parse(commandParts[2]);

                if (direction=="left")
                {
                    flyLenght *= -1;
                }

                // outside of the field
                if (currentladybugIndex<0||currentladybugIndex>=size)
                {
                    continue;
                }

                // no ladybug here
                if (field[currentladybugIndex]==0)
                {
                    continue;
                }

                field[currentladybugIndex] = 0; // fly away

                var nextIndexToland = currentladybugIndex;

                while (true)
                {
                    nextIndexToland += flyLenght;

                    if (nextIndexToland<0||nextIndexToland>=size)
                    {
                        break;
                    }

                    if (field[nextIndexToland]==1) // there is ladybug in
                    {
                        continue;
                    }

                    field[nextIndexToland] = 1;
                    break;  // just landed
                }

            }

            Console.WriteLine(string.Join(" ",field));
        }
    }
}
