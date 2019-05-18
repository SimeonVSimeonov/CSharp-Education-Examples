using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ManagerController managerController;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.managerController = new ManagerController();
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = this.reader.ReadLine()) != "Exit")
            {
                try
                {
                    this.ReadCommand(input);
                }
                catch (Exception e)
                {
                    this.writer.WriteLine(e.Message);
                }
            }
        }

        private void ReadCommand(string input)
        {
            //•	AddPlayer { player type} { player username}
            //•	AddCard { card type}  { card name}
            //•	AddPlayerCard { username} { card name}
            //•	Fight { attack user} { enemy user}
            //•	Report

            var output = String.Empty;
            string[] args = input.Split().ToArray();
            var command = args[0];
            var tokens = args.Skip(1).ToArray();

            switch (command)
            {
                case "AddPlayer":
                    var playerType = tokens[0];
                    var username = tokens[1];
                    output = managerController.AddPlayer(playerType, username);
                    break;
                case "AddCard":
                    var cardType = tokens[0];
                    var cardName = tokens[1];
                    output = managerController.AddCard(cardType, cardName);
                    break;
                case "AddPlayerCard":
                    username = tokens[0];
                    cardName = tokens[1];
                    output = managerController.AddPlayerCard(username, cardName);
                    break;
                case "Fight":
                    var attakerName = tokens[0];
                    var enemyName = tokens[1];
                    output = managerController.Fight(attakerName, enemyName);
                    break;
                case "Report":
                    output = managerController.Report();
                    break;
            }

            if (output != string.Empty)
            {
                writer.WriteLine(output);
            }

        }
    }
}
