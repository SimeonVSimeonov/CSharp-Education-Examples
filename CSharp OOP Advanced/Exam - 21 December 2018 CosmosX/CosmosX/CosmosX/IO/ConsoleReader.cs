﻿using System;
using CosmosX.IO.Contracts;

namespace CosmosX.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            //return Console.ReadKey().ToString().ToString().ToLower().ToString().ToLower();
            return Console.ReadLine();
        }
    }
}