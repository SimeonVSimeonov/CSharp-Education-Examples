using System;
using System.Collections.Generic;
using System.Text;

namespace P04OnlineRadioDatabase.Exeptions
{
    public class InvalidSongLengthException : InvalidSongException
    {
        public InvalidSongLengthException(string message = "Invalid song length.") 
            : base(message)
        {

        }
    }
}
