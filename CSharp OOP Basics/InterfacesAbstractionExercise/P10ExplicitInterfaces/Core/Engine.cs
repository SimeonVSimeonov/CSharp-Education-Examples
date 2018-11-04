using P10ExplicitInterfaces.Contracts;
using P10ExplicitInterfaces.Models;
using System;

namespace P10ExplicitInterfaces.Core
{
    public class Engine
    {
        public void Run()
        {
            Action<IPerson> PrintPerson = x => Console.WriteLine(x.GetName());
            Action<IResident> PrintResident = x => Console.WriteLine(x.GetName());

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var inputArgs = input.Split();
                Citizen citizen = new Citizen(inputArgs[0], inputArgs[1], inputArgs[2]);
                PrintPerson(citizen);
                PrintResident(citizen);
            }
        }
    }
}
