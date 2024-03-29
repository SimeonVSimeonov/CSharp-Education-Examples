﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P06Animals.Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                if (value == null || string.IsNullOrEmpty(value))
                {
                    throw new Exception("Invalid input!");
                }
                name = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }

            private set
            {
                if (value == null || string.IsNullOrEmpty(value))
                {
                    throw new Exception("Invalid input!");
                }
                gender = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            private set
            {
                if (value < 0)
                {
                    throw new Exception("Invalid input!");
                }
                age = value;
            }
        }

        public virtual void ProduceSound()
        {
            Console.WriteLine("Make Screeeeam");
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Gender}";
        }
    }
}
