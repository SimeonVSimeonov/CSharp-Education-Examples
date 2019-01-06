using System;
using System.Collections.Generic;
using System.Linq;

namespace P02GrainsOfSands
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = new List<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            string input;

            while ((input = Console.ReadLine()) != "Mort")
            {
                var data = input.Split();
                var command = data[0];
                var value = int.Parse(data[1]);
                var replaceValue = 0;

                if (data.Length == 3)
                {
                    replaceValue = int.Parse(data[2]);
                }

                switch (command)
                {
                    case "Add":
                        sequence.Add(value);
                        break;
                    case "Remove":
                        if (sequence.Contains(value))
                        {
                            sequence.Remove(value);
                        }
                        else if (sequence.Count >= value - 1 && value >= 0)
                        {
                            var element = sequence[value];
                            sequence.Remove(element);
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case "Replace":
                        if (sequence.Contains(value))
                        {
                            var position = sequence.IndexOf(value);
                            sequence.Remove(value);
                            sequence.Insert(position, replaceValue);
                        }
                        break;
                    case "Increase":
                        var incElement = 0;

                        foreach (var item in sequence)
                        {
                            if (item >= value)
                            {
                                incElement = item;
                            }
                            else
                            {
                                incElement = sequence.Last();
                            }
                        }

                        for (int i = 0; i < sequence.Count; i++)
                        {
                            sequence[i] += incElement;
                        }
                        break;
                    case "Collapse":
                        sequence.RemoveAll(e => e < value);
                        break;
                }
            }

            Console.WriteLine(string.Join(' ', sequence));
        }
    }
}