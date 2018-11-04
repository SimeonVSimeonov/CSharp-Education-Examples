using P05BorderControl.Contracts;
using P05BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P05BorderControl.Core
{
    public class Engine
    {
        private ICollection<IIdentifable> creatures;

        public Engine()
        {
            this.creatures = new List<IIdentifable>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input.Split();

                if (inputArgs.Length == 2)
                {
                    string model = inputArgs[0];
                    string id = inputArgs[1];

                    IIdentifable robot = new Robot(model, id);
                    this.creatures.Add(robot);
                }
                else
                {
                    string name = inputArgs[0];
                    int age = int.Parse(inputArgs[1]);
                    string id = inputArgs[2];

                    IIdentifable citizen = new Citizen(name, age, id);
                    this.creatures.Add(citizen);
                }

                input = Console.ReadLine();
            }

            string fakeId = Console.ReadLine();

            foreach (var item in this.creatures.Where(x => x.Id.EndsWith(fakeId)))
            {
                Console.WriteLine(item.Id);
            }

            this.creatures = this.creatures.Where(x => !x.Id.EndsWith(fakeId)).ToList();
        }

    }
}
