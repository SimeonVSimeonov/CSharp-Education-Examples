using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Snowwhite
{
    class Dwarf
    {
        public string Name { get; set; }

        public string Color { get; set; }

        public int Physics { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var colourToDwarf = new Dictionary<string, List<Dwarf>>();
            var allDwarf = new List<Dwarf>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line== "Once upon a time")
                {
                    break;
                }

                string[] dwarfInfo = line.Split(new char[] { ' ','>','<',':' }, StringSplitOptions.RemoveEmptyEntries);

                string name = dwarfInfo[0];
                string color = dwarfInfo[1];
                int physics = int.Parse(dwarfInfo[2]);

                if (!colourToDwarf.ContainsKey(color))
                {
                    colourToDwarf[color] = new List<Dwarf>();
                }

                var dwarfsByCurrentColour = colourToDwarf[color];

                var foundDwarf = dwarfsByCurrentColour
                    .FirstOrDefault(d => d.Name == name);

                if (foundDwarf!=null)
                {
                    foundDwarf.Physics = Math.Max(physics, foundDwarf.Physics);
                }
                else
                {
                    var dwarf = new Dwarf
                    {
                        Name = name,
                        Color = color,
                        Physics = physics
                    };

                    dwarfsByCurrentColour.Add(dwarf);
                    allDwarf.Add(dwarf);
                }
            }

            var result = allDwarf
                .OrderByDescending(d => d.Physics)
                .ThenByDescending(d => colourToDwarf[d.Color].Count())
                .ToList();
            foreach (var dwarf in result )
            {
                Console.WriteLine($"({dwarf.Color}) {dwarf.Name} <-> {dwarf.Physics}");
            }
        }
    }
}
