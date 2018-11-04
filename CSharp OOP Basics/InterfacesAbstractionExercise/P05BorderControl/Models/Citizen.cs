using System;
using System.Collections.Generic;
using System.Text;
using P05BorderControl.Contracts;

namespace P05BorderControl.Models
{
    public class Citizen : IIdentifable
    {
        private string name;
        private int age;
        private string id;

        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Name
        {
            get => name;
            private set => name = value;
        }

        public int Age
        {
            get => age;
            private set => age = value;
        }

        public string Id
        {
            get => id;
            private set => id = value;
        }
    }
}
