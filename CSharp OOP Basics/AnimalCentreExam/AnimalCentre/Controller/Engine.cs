using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Controller
{
    public class Engine
    {
        private AnimalCentre animalCentre;

        public Engine()
        {
            this.animalCentre = new AnimalCentre();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input.Split();

                string command = inputArgs[0];
                string[] args = inputArgs.Skip(1).ToArray();

                string result = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "RegisterAnimal":
                            {
                                var type = args[0];
                                var name = args[1];
                                var energy = int.Parse(args[2]);
                                var happiness = int.Parse(args[3]);
                                var procedureTime = int.Parse(args[4]);
                                result = animalCentre.RegisterAnimal(type, name, energy, happiness, procedureTime);
                            }                       
                            break;
                        case "Chip":
                            {
                                var name = args[0];
                                var procedureTime = int.Parse(args[1]);
                                result = animalCentre.Chip(name, procedureTime);
                            }      
                            
                            break;
                        case "Vaccinate":
                            {
                                var name = args[0];
                                var procedureTime = int.Parse(args[1]);
                                result = animalCentre.Vaccinate( name,procedureTime);
                            }
                            break;
                        case "Fitness":
                            {
                                var name = args[0];
                                var procedureTime = int.Parse(args[1]);
                                result = animalCentre.Fitness(name,procedureTime);
                            }
                            break;
                        case "Play":
                            {
                                var name = args[0];
                                var procedureTime = int.Parse(args[1]);
                                result = animalCentre.Play( name,  procedureTime);
                            }
                            break;
                        case "DentalCare":
                            {
                                var name = args[0];
                                var procedureTime = int.Parse(args[1]);
                                result = animalCentre.DentalCare( name,  procedureTime);
                            }
                            break;
                        case "NailTrim":
                            {
                                var name = args[0];
                                var procedureTime = int.Parse(args[1]);
                                result = animalCentre.NailTrim( name, procedureTime);
                            }
                            break;
                        case "Adopt":
                            {
                                var animalName = args[0];
                                var owner = args[1];
                                result = animalCentre.Adopt( animalName,  owner);
                            }
                            break;
                        case "History":
                            {
                                var type = args[0];
                                result = animalCentre.History(type);
                            }
                            break;

                        default:
                            break;
                    }

                    Console.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("InvalidOperationException:" + ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("ArgumentException:" + ex.Message);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Final stats:");
           // Console.WriteLine(animalCentre.History(type));

        }

    }
}

