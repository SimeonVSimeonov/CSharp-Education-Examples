using MyApp.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Commands
{
    public class ExitCommand : ICommand
    {
        public string Execute(string[] inputArgs)
        {
            return "exit";
        }
    }
}
