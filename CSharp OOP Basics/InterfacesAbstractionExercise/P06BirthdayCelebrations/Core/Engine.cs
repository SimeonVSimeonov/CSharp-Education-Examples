using P06BirthdayCelebrations.Contracts;
using P06BirthdayCelebrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P06BirthdayCelebrations.Core
{
    public class Engine
    {
        private ICollection<IIdentifable> creatures;
        private ICollection<IBirthable> birthables;

        public Engine()
        {
            this.creatures = new List<IIdentifable>();
            this.birthables = new List<IBirthable>();
        }

        public void Run()
        {

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input.Split();

                string type = inputArgs[0];

                if (type == "Robot")
                {
                    string model = inputArgs[1];
                    string id = inputArgs[2];

                    IIdentifable robot = new Robot(model, id);
                    this.creatures.Add(robot);
                }
                else if (type == "Citizen")
                {
                    string name = inputArgs[1];
                    int age = int.Parse(inputArgs[2]);
                    string id = inputArgs[3];
                    string birthdate = inputArgs[4];

                    IBirthable citizen = new Citizen(name, age, id, birthdate);
                    this.birthables.Add(citizen);
                }
                else if (type == "Pet")
                {
                    string name = inputArgs[1];
                    string birthdate = inputArgs[2];

                    IBirthable pet = new Pet(name, birthdate);
                    this.birthables.Add(pet);
                }


                input = Console.ReadLine();
            }

            string year = Console.ReadLine();

            foreach (var item in this.birthables.Where(x => x.Birthdate.EndsWith(year)))
            {
                Console.WriteLine(item.Birthdate);
            }

            this.birthables = this.birthables.Where(x => !x.Birthdate.EndsWith(year)).ToList();
        }

    }
}
