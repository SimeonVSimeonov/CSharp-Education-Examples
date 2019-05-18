using PlayersAndMonsters.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.IO
{
    public class Writer : IWriter
    {
        private StringBuilder sb;

        public void Write(string message)
        {
            this.sb = new StringBuilder();
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
