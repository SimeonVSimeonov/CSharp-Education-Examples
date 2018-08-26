using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //DateTime endOfTheWorld = DateTime.MaxValue;
            //Console.WriteLine("{0:D}",endOfTheWorld);


            //Random rnd = new Random();
            //Console.WriteLine(rnd.Next(100,200));

            //string[] words = Console.ReadLine().Split();

            //Random random = new Random();

            //for (int i = 0; i < words.Length; i++)
            //{
            //    int pos = random.Next(0, words.Length);

            //    string temp = words[1];
            //    words[1] = words[pos];
            //    words[pos] = temp;
            //}
            //Console.WriteLine(string.Join(" ",words));

            Student student = new Student()
            {
                Name = "Pesho",
                Age = 25
            };
            student.Age = 30;

        }
    }
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void PrintStudent()
        {
            Console.WriteLine(Name + " - "+ Age);
        }

    }
}
