﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P04OnlineRadioDatabase.Exeptions
{
    public class InvalidArtistNameException : InvalidSongException
    {
        public InvalidArtistNameException(string message = "Artist name should be between 3 and 20 symbols.") 
            : base(message)
        {

        }
    }
}
