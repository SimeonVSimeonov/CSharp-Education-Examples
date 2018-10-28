using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Person person1 = new Person("Pesho", 22);
            Person person2 = new Person("Gosho", 24);
            Person person3 = new Person("Stamat", 22);

            Console.WriteLine(person2.Name);
        }
    }
}
