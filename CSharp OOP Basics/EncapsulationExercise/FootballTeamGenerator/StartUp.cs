﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Team> teams = new List<Team>();

            while (command != "END")
            {
                string[] tokens = command.Split(';', StringSplitOptions.RemoveEmptyEntries);
                switch (tokens[0])
                {
                    case "Team":
                        teams.Add(new Team(tokens[1]));
                        break;
                    case "Add":
                        string teamName = tokens[1];
                        string playerName = tokens[2];
                        int endurance = int.Parse(tokens[3]);
                        int sprint = int.Parse(tokens[4]);
                        int dribble = int.Parse(tokens[5]);
                        int passing = int.Parse(tokens[6]);
                        int shooting = int.Parse(tokens[7]);

                        bool teamExists = teams.Any(t => t.Name == teamName);
                        Team team;

                        if (!teamExists)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            try
                            {
                                team = teams.Where(t => t.Name == teamName).First();
                                Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                                team.AddPayer(player);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case "Remove":
                        teamName = tokens[1];
                        team = teams.Where(t => t.Name == teamName).First();
                        playerName = tokens[2];
                        try
                        {
                            team.RemovePlayer(playerName);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "Rating":
                        teamName = tokens[1];
                        teamExists = teams.Any(t => t.Name == teamName);
                        if (!teamExists)
                        {
                            Console.WriteLine("Team {0} does not exist.", teamName);
                        }
                        else
                        {
                            team = teams.Where(t => t.Name == teamName).First();
                            Console.WriteLine($"{team.Name} - {team.Rating()}");
                        }
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
