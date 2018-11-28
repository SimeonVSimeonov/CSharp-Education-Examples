namespace P05ComparingObjects
{
    using System;

    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Town { get => town; set => town = value; }

        public int CompareTo(Person other)
        {
            if (this.name.CompareTo(other.name)!=0)
            {
                return this.name.CompareTo(other.name);
            }

            if (this.age.CompareTo(other.age)!=0)
            {
                return this.age.CompareTo(other.age);
            }

            return this.town.CompareTo(other.town);
        }
    }
}
