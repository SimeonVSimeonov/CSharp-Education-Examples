﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                var inputArgs = Console.ReadLine().Split();
                var person = new Person(inputArgs[0], inputArgs[1], int.Parse(inputArgs[2]));
                persons.Add(person);
            }

            persons.OrderBy(x => x.FirstName)
                .ThenBy(x => x.Age)
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));
        }
    }
}
