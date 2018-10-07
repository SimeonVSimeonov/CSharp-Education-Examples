using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            var students = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] elements = input.Split(':');

                string contestName = elements[0];
                string password = elements[1];

                if (!contests.ContainsKey(contestName))
                {
                    contests.Add(contestName, password);
                }


                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "end of submissions")
            {

                string[] elements = input.Split("=>");

                string contestName = elements[0];
                string contestPassword = elements[1];
                string username = elements[2];
                int currentPoints = int.Parse(elements[3]);

                if (contests.ContainsKey(contestName) && contests[contestName] == contestPassword)
                {
                    if (!students.ContainsKey(username))
                    {
                        students.Add(username, new Dictionary<string, int>());
                    }

                    if (!students[username].ContainsKey(contestName))
                    {
                        students[username].Add(contestName, currentPoints);
                    }

                    if (students[username][contestName] < currentPoints)
                    {
                        students[username][contestName] = currentPoints;
                    }
                }

                input = Console.ReadLine();
            }

            var topStudent = students.OrderByDescending(x => x.Value.Sum(s => s.Value)).FirstOrDefault();

            Console.WriteLine($"Best candidate is {topStudent.Key} with total {topStudent.Value.Sum(x => x.Value)} points.");

            Console.WriteLine("Ranking:");

            var sortedStudents = students.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);

            foreach (var kvp in sortedStudents)
            {
                Console.WriteLine(kvp.Key);

                foreach (var contest in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
