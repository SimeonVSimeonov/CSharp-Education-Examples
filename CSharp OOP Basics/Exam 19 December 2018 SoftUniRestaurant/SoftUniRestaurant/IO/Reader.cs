using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.IO
{
    public class Reader : IReader
    {
        public string ReadData()
        {
            return Console.ReadLine();
        }
    }
}
