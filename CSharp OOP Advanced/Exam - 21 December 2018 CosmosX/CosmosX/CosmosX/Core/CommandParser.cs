﻿using System.Collections.Generic;
using System.Linq;
using CosmosX.Core.Contracts;

namespace CosmosX.Core
{
    public class CommandParser : ICommandParser
    {
        private const string CommandNameSuffix = "Command";

        private readonly IManager reactorManager;

        public CommandParser(IManager reactorManager)
        {
            this.reactorManager = reactorManager;
        }

        public string Parse(IList<string> arguments)
        {
            string command = arguments[0] + CommandNameSuffix; //TODO

            string[] commandArguments = arguments.Skip(1).ToArray();
            ;
            string result = string.Empty;

            var method = this.reactorManager.GetType().GetMethods().FirstOrDefault(x => x.Name == command);

            result = (string)method.Invoke(this.reactorManager, new object[] { commandArguments });

            //switch (command)
            //{
            //    case "Reactor":
            //        result = this.reactorManager.ReactorCommand(commandArguments);
            //        break;
            //    case "Module":
            //        result = this.reactorManager.ModuleCommand(commandArguments);
            //        break;
            //    case "Report":
            //        result = this.reactorManager.ReportCommand(commandArguments);
            //        break;
            //    case "Exit":
            //        result = this.reactorManager.ExitCommand(commandArguments);
            //        break;
            //}

            return result;
        }
    }
}