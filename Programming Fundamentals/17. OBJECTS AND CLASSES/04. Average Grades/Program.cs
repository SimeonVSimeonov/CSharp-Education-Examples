using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Average_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> ourClass = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                List<string> input = Console.ReadLine().Split(' ').ToList();
                Student student = new Student();
                student.Name = input[0];
                input.RemoveAt(0);
                student.Grade = input.Select(double.Parse).ToList();
                ourClass.Add(student);
            }
            foreach (var person in ourClass.Where(x => x.AverageGrade>=5).OrderBy(x => x.Name).ThenByDescending(x=>x.AverageGrade))
            {
                Console.WriteLine($"{person.Name} -> {person.AverageGrade:F2}");
            }
        }
    }
    class Student
    {
        public string Name { get; set; }
        public List<double> Grade { get; set; }
        public double AverageGrade { get { return Grade.Average(); } }
    }
}
