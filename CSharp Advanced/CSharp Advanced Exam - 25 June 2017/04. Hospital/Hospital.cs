using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Hospital
{
    class Hospital
    {
        static void Main(string[] args)
        {
            var departaments = new Dictionary<string, List<string>>();
            var doctors = new Dictionary<string, List<string>>();

            string input;

            while ((input = Console.ReadLine()) != "Output")
            {
                string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string departament = inputArgs[0];
                string doctor = inputArgs[1] + " " + inputArgs[2];
                string patient = inputArgs[3];

                if (!departaments.ContainsKey(departament))
                {
                    departaments.Add(departament, new List<string>());
                }
                departaments[departament].Add(patient);

                if (!doctors.ContainsKey(doctor))
                {
                    doctors.Add(doctor, new List<string>());
                }
                doctors[doctor].Add(patient);

            }

            while ((input = Console.ReadLine()) != "End")
            {
                string[] commandArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (commandArgs.Length == 1)
                {
                    foreach (var item in departaments[commandArgs[0]])
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (Char.IsDigit(commandArgs[1][0]))
                {
                    int room = int.Parse(commandArgs[1]);

                    departaments[commandArgs[0]]
                        .Skip(3 * (room - 1))
                        .Take(3)
                        .OrderBy(s => s)
                        .ToList()
                        .ForEach(Console.WriteLine);
                }
                else
                {
                    doctors[commandArgs[0] + " " + commandArgs[1]]
                        .OrderBy(x => x)
                        .ToList()
                        .ForEach(Console.WriteLine);
                }
            }

        }
    }
}
