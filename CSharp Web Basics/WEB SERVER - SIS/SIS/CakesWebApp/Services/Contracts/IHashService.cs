using System;
using System.Collections.Generic;
using System.Text;

namespace CakesWebApp.Services.Contracts
{
    public interface IHashService
    {
        string Hash(string stringToHash);
    }
}
