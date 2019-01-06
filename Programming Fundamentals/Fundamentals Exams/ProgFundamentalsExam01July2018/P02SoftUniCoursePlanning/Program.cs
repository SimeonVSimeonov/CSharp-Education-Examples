using System;
using System.Collections.Generic;
using System.Linq;

namespace P02SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {

            var schedule = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string command;

            while ((command = Console.ReadLine()) != "course start")
            {
                var tokens = command.Split(':').ToArray();
                var commandType = tokens[0];

                switch (commandType)
                {
                    case "Add":
                        if (!schedule.Contains(tokens[1]))
                        {
                            schedule.Add(tokens[1]);
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case "Insert":
                        var index = int.Parse(tokens[2]);
                        if (!schedule.Contains(tokens[1]) && schedule.Count > index)
                        {
                            schedule.Insert(index, tokens[1]);
                        }
                        break;
                    case "Remove":
                        if (schedule.Contains(tokens[1]))
                        {
                            schedule.Remove(tokens[1]);
                        }
                        if (schedule.Contains(tokens[1] + "-Exercise"))
                        {
                            schedule.Remove(tokens[1] + "-Exercise");
                        }
                        break;
                    case "Swap":
                        if (schedule.Contains(tokens[1]) && schedule.Contains(tokens[2]))
                        {
                            var idx1 = schedule.IndexOf(tokens[1]);
                            var idx2 = schedule.IndexOf(tokens[2]);

                            var tmp = schedule[idx1];
                            schedule[idx1] = schedule[idx2];
                            schedule[idx2] = tmp;

                            if (schedule.Contains(tokens[1] + "-Exercise"))
                            {
                                var idx = schedule.IndexOf(tokens[1]);
                                schedule.Remove(tokens[1] + "-Exercise");
                                schedule.Insert(idx + 1, tokens[1] + "-Exercise");
                            }
                            if (schedule.Contains(tokens[2] + "-Exercise"))
                            {
                                var idx = schedule.IndexOf(tokens[2]);
                                schedule.Remove(tokens[2] + "-Exercise");
                                schedule.Insert(idx + 1, tokens[2] + "-Exercise");
                            }
                        }
                        break;
                    case "Exercise":
                        if (schedule.Contains(tokens[1]) && !schedule.Contains(tokens[1] + "-Exercise"))
                        {
                            var lesonIdx = schedule.IndexOf(tokens[1]);
                            schedule.Insert(lesonIdx + 1, tokens[1] + "-Exercise");
                        }
                        if (!schedule.Contains(tokens[1]))
                        {
                            schedule.Add(tokens[1]);
                            schedule.Add(tokens[1] + "-Exercise");
                        }
                        break;

                }
            }

            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{schedule[i]}");
            }
        }
    }
}
