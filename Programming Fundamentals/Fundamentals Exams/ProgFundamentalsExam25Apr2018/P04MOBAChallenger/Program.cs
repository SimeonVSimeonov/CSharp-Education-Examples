using System;
using System.Collections.Generic;
using System.Linq;

namespace P04MOBAChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            var playerPool = new Dictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine()) != "Season end")
            {
                var playerTokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                if (playerTokens.Length==3)
                {
                    var playerName = playerTokens[0];
                    var position = playerTokens[1];
                    var skill = int.Parse(playerTokens[2]);

                    if (!playerPool.ContainsKey(playerName))
                    {
                        playerPool.Add(playerName, new Dictionary<string, int>());
                    }
                    if (playerPool[playerName].ContainsKey(position) && (playerPool[playerName][position] > skill))
                    {
                        continue;
                    }
                    playerPool[playerName].Add(position, skill);
                }
               

                var duelTokens = input.Split(" vs ", StringSplitOptions.RemoveEmptyEntries);
                if (duelTokens.Length==2)
                {
                    var player1 = duelTokens[0];
                    var player2 = duelTokens[1];

                    if (playerPool.ContainsKey(player1) && playerPool.ContainsKey(player2))
                    {
                        foreach (var item in playerPool[player1].Keys)
                        {   
                            if (playerPool[player2].Keys.Contains(item))
                            {
                                if (playerPool[player1][item]>playerPool[player2][item])
                                {
                                    playerPool.Remove(player2);
                                }
                                else if (playerPool[player1][item] < playerPool[player2][item])
                                {
                                    playerPool.Remove(player1);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                }
            }

            foreach (var player in playerPool.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"{player.Key}: {playerPool[player.Key].Values.Sum()} skill");

                foreach (var item in player.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {item.Key} <::> {item.Value}");
                }
            }
        }
    }
}
