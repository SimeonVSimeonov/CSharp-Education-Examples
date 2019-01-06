using System;
using System.Linq;

namespace P03TseamAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var account = Console.ReadLine().Split().ToList();

            while ((input = Console.ReadLine()) != "Play!")
            {
                var command = input.Split()[0];
                var game = string.Empty;
                var expan = string.Empty;

                switch (command)
                {
                    case "Install":
                        game = input.Split()[1];
                        if (!account.Contains(game))
                        {
                            account.Add(game);
                        }
                        break;
                    case "Uninstall":
                        game = input.Split()[1];
                        if (account.Contains(game))
                        {
                            account.Remove(game);
                        }
                        break;
                    case "Update":
                        game = input.Split()[1];
                        if (account.Contains(game))
                        {
                            account.Remove(game);
                            account.Add(game);
                        }
                        break;
                    case "Expansion":
                        var tokens = input.Split()[1];
                        game = tokens.Split('-')[0];
                        expan = tokens.Split('-')[1];

                        if (account.Contains(game))
                        {
                            var indx = account.IndexOf(game);
                            account.Insert(indx + 1, game + ":" + expan);
                        }

                        break;
                }
            }

            Console.WriteLine(string.Join(' ', account));
        }
    }
}