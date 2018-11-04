﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P06Animals.Animals
{
    class Tomcat : Cat
    {
        private const string gender = "Male";

        public Tomcat(string name, int age) 
            : base(name, age, gender)
        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("MEOW");
        }
    }
}
