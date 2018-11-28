namespace P06StrategyPattern
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            SortedSet<Person> peopleByName = new SortedSet<Person>(new NameComparators());
            SortedSet<Person> peopleByAge = new SortedSet<Person>(new AgeComparators());

            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split();

                Person person = new Person(input[0], int.Parse(input[1]));

                peopleByName.Add(person);
                peopleByAge.Add(person);

            }

            foreach (Person person in peopleByName)
            {
                Console.WriteLine(person);
            }

            foreach (Person person in peopleByAge)
            {
                Console.WriteLine(person);
            }
        }
    }
}
