using System;
using System.Collections.Generic;
using System.Linq;

namespace _13._Family_Tree
{
    class StartUp
    {
        static List<Person> persons;
        static List<string> relationships;

        static void Main(string[] args)
        {

            persons = new List<Person>();
            relationships = new List<string>();

            string mainPersonInfo = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "End")
            {
                if (!input.Contains("-"))
                {
                    AddMember(input);
                    input = Console.ReadLine();
                    continue;
                }

                relationships.Add(input);
                input = Console.ReadLine();
            }

            foreach (var membersInf in relationships)
            {
                //11 / 11 / 1951 - 23 / 5 / 1980
                //Penka Pesheva -23 / 5 / 1980
                //Penka Pesheva 9 / 2 / 1953

                string[] inputArgs = membersInf.Split(new string[] { " - " },
                    StringSplitOptions.RemoveEmptyEntries);

                Person parent = GetPerson(inputArgs[0]);
                Person child = GetPerson(inputArgs[1]);

                if (!parent.Children.Contains(child))
                {
                    parent.Children.Add(child);
                }

                if (!child.Parents.Contains(parent))
                {
                    child.Parents.Add(parent);
                }

            }

            Print(mainPersonInfo);

        }

        private static void Print(string mainPersonInfo)
        {
            Person mainPerson = GetPerson(mainPersonInfo);

            Console.WriteLine($"{mainPerson.Name} {mainPerson.Birthday}");
            Console.WriteLine("Parents:");

            foreach (var parent in mainPerson.Parents)
            {
                Console.WriteLine($"{parent.Name} {parent.Birthday}");
            }

            Console.WriteLine("Children:");

            foreach (var child in mainPerson.Children)
            {
                Console.WriteLine($"{child.Name} {child.Birthday}");
            }
        }

        private static Person GetPerson(string input)
        {
            if (input.Contains("/"))
            {
                return persons.FirstOrDefault(x => x.Birthday == input);
            }

            return persons.FirstOrDefault(x => x.Name == input);
        }

        private static void AddMember(string input)
        {
            //Pesho Peshev 23/5/1980

            string[] inputArgs = input.Split();
            string name = inputArgs[0] + " " + inputArgs[1];
            string birthday = inputArgs[2];

            Person person = new Person(name, birthday);
            persons.Add(person);

        }
    }
}
