﻿namespace TheTankGame.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }
        
        public string ProcessInput(IList<string> inputParameters)
        {
            string commandName = inputParameters[0];
            inputParameters.RemoveAt(0);

            string result = string.Empty;
            MethodInfo command;

            if (commandName == "Vehicle" || commandName == "Part")
            {
                command = this.tankManager
                    .GetType()
                    .GetMethods()
                    .FirstOrDefault(x => x.Name == "Add" + commandName);
            }
            else
            {
                command = this.tankManager
                    .GetType()
                    .GetMethods()
                    .FirstOrDefault(x => x.Name == commandName);
            }

            result = (string)command.Invoke(this.tankManager, new object[] { inputParameters });
            return result;
        }
    }
}