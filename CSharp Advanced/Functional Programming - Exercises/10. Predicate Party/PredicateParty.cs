using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party
{
    class PredicateParty
    {
        static void Main(string[] args)
        {
            Predicate<string> predicate;
            Action<List<string>> print = names => Console.WriteLine(string.Join(", ", names) + " are going to the party!");

            List<string> guests = Console.ReadLine().Split().ToList();

            string input = Console.ReadLine();

            while (input != "Party!")
            {
                string[] commandArgs = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);

                string command = commandArgs[0];
                string predicateName = commandArgs[1];
                string value = commandArgs[2];

                predicate = GetPredicate(predicateName, value);

                if (command=="Remove")
                {
                    guests.RemoveAll(predicate);
                }
                else
                {
                    var newGuest = guests.FindAll(predicate);

                    foreach (var guest in newGuest)
                    {
                        int indexOfCurrebtGuest = guests.IndexOf(guest);

                        guests.Insert(indexOfCurrebtGuest + 1, guest);
                    }
                }
                input = Console.ReadLine();
            }

            if (guests.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                print(guests);
            }
        }

        private static Predicate<string> GetPredicate(string predicateName, string value)
        {
            if (predicateName == "StartsWith")
            {
                return p => p.StartsWith(value);
            }
            else if (predicateName == "EndsWith")
            {
                return p => p.EndsWith(value);
            }
            else if (predicateName == "Length")
            {
                return p => p.Length == int.Parse(value);
            }

            return null;
        }
    }
}
