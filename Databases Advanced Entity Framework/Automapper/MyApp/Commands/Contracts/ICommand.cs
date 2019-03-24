using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(string[] inputArgs);
    }
}
