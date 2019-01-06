using System;

namespace P01SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeCount = 3;
            var allEmployeeEfficiency = 0;
            var time = 0;

            for (int i = 0; i < employeeCount; i++)
            {
                var eachEmployeeEfficiency = int.Parse(Console.ReadLine());
                allEmployeeEfficiency += eachEmployeeEfficiency;
            }
            var studentsCount = int.Parse(Console.ReadLine());

            while (studentsCount > 0)
            {
                time++;

                if (time % 4 == 0)
                {

                    continue;
                }
                else
                {
                    studentsCount -= allEmployeeEfficiency;
                }

            }

            Console.WriteLine($"Time needed: {time}h.");
        }
    }
}
