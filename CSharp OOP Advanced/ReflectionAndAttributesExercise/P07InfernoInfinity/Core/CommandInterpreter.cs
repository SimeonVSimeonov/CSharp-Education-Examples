namespace P07InfernoInfinity.Core
{
    using P07InfernoInfinity.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        public IExecutable InterpretCommand(string commandName, string[] data)
        {
            var command = commandName + "Command";
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == command);

            IExecutable instance = (IExecutable)Activator.CreateInstance(type, new object[] { data });

            return instance;
        }
    }
}
