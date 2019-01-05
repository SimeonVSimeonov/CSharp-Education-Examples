namespace TheTankGame.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader,
            IWriter writer,
            ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string input;

            while ((input = this.reader.ReadLine()) != "Terminate")
            {
                IList<string> args = input.Split().ToList();
                var result = this.commandInterpreter.ProcessInput(args);
                this.writer.WriteLine(result);
            }

            string terminate = this.commandInterpreter.ProcessInput(new List<string> { "Terminate" });
            this.writer.WriteLine(terminate);
        }
    }
}