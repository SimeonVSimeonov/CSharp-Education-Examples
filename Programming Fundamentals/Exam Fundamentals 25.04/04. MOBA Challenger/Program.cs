using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, int>>();
            bool isRemoved = false;
            var input = string.Empty;
            while ((input = Console.ReadLine()) != "Season end")
            {
                isRemoved = false;
                if (input.Contains("->"))
                {
                    var tokens = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    var player = tokens[0];
                    var position = tokens[1];
                    var skill = int.Parse(tokens[2]);
                    if (!dict.ContainsKey(player))
                    {
                        dict[player] = new Dictionary<string, int>();
                        dict[player][position] = skill;

                    }
                    else if (dict.ContainsKey(player))
                    {
                        if (!dict[player].ContainsKey(position))
                        {
                            dict[player][position] = skill;
                        }
                        else if (dict[player].ContainsKey(position))
                        {
                            foreach (var ch in dict)
                            {
                                var playr = ch.Key;
                                if (player == playr)
                                {
                                    var postns = ch.Value;
                                    foreach (var ps in postns)
                                    {
                                        if (ps.Key == position)
                                        {
                                            if (ps.Value < skill)
                                            {
                                                dict[player][position] = skill;
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
                else if (input.Contains("vs"))
                {
                    var tokens = input.Split(new string[] { " vs " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    var playerOne = tokens[0];
                    var playerTwo = tokens[1];
                    if (dict.ContainsKey(playerOne) && dict.ContainsKey(playerTwo))
                    {
                        foreach (var h in dict)
                        {
                            if (h.Key == playerOne)
                            {
                                foreach (var t in h.Value)
                                {
                                    if (dict[playerTwo].ContainsKey(t.Key))
                                    {
                                        var playerOneSum = 0;
                                        var playertwoSum = 0;
                                        foreach (var m in dict)
                                        {

                                            if (playerOne == m.Key)
                                            {
                                                foreach (var p in m.Value)
                                                {
                                                    playerOneSum = m.Value.Values.Sum();
                                                }
                                            }
                                            else if (playerTwo == m.Key)
                                            {
                                                foreach (var p in m.Value)
                                                {
                                                    playertwoSum = m.Value.Values.Sum();
                                                }
                                            }
                                        }

                                        if (playerOneSum > playertwoSum)
                                        {
                                            dict.Remove(playerTwo);
                                            isRemoved = true;
                                            break;
                                        }
                                        else if (playertwoSum > playerOneSum)
                                        {
                                            dict.Remove(playerOne);
                                            isRemoved = true;
                                            break;
                                        }
                                    }

                                }

                                if (isRemoved)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            foreach (var plrs in dict.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                var name = plrs.Key;
                var pos = plrs.Value;
                Console.WriteLine($"{name}: {plrs.Value.Values.Sum()} skill");
                foreach (var n in pos.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {n.Key} <::> {n.Value}");
                }
            }
        }
    }
}
