﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P06Animals.Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int age, string gender)
            : base(name, age, gender)
        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }
    }
}
