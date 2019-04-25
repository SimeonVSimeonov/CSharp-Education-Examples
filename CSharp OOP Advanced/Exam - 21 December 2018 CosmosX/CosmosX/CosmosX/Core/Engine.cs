using CosmosX.Core.Contracts;
using CosmosX.IO.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace CosmosX.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandParser commandParser;
        private bool isRunning;

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandParser = commandParser;
            this.isRunning = false;
        }

        public void Run()
        {
            string input;

            while ((input = this.reader.ReadLine()) != "Exit")
            {
                IList<string> arguments = input.Split().ToList();
                var result = this.commandParser.Parse(arguments);
                this.writer.WriteLine(result);
            }
            ;
            if (input == "Exit")
            {
                IList<string> arguments = input.Split().ToList();
                var result = this.commandParser.Parse(arguments);
                this.writer.WriteLine(result);
            }
        }
    }
}