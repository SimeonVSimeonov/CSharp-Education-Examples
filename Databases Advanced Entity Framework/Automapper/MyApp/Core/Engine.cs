using MyApp.Core.Contracts;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApp.Core
{
    public class Engine : IEngine
    {
        private readonly IServiceProvider provider;

        public Engine(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public void Run()
        {
            while (true)
            {
                string[] inputArgs = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .ToArray();

                var commandInterpreter = this.provider.GetService<ICommandInterpreter>();
                string result = commandInterpreter.Read(inputArgs);
                
                if (result == "exit")
                {
                    Environment.Exit(-1);
                }

                Console.WriteLine(result);

                //TODO add try catch block
            }
        }
    }
}
