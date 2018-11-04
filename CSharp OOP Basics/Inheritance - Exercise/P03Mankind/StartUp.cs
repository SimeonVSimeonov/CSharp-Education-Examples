using System;

namespace P03Mankind
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Student student;
            Worker worker;
            var inputStudent = Console.ReadLine().Split();
            var inputWorker = Console.ReadLine().Split();

            try
            {
                var firstName = inputStudent[0];
                var lastName = inputStudent[1];
                var facultyNumber = inputStudent[2];

                student = new Student(firstName, lastName, facultyNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            try
            {
                var firstName = inputWorker[0];
                var lastName = inputWorker[1];
                var weekSalary = int.Parse(inputWorker[2]);
                var workHoursDay = int.Parse(inputWorker[3]);

                worker = new Worker(firstName, lastName, weekSalary, workHoursDay);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(worker);
        }
    }
}
