using System;

namespace _01._Define_a_Class_Person
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Pesho", 22);

            Console.WriteLine(person1.Age);
        }
    }
}
