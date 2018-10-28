using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Company_Roster
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                //Pesho 120.00 Dev Development pesho@abv.bg 28

                var name = inputArgs[0];
                var salary = decimal.Parse(inputArgs[1]);
                var position = inputArgs[2];
                var department = inputArgs[3];

                Employee employee = new Employee(name, salary, position, department);

                if (inputArgs.Length == 5)
                {
                    if (int.TryParse(inputArgs[4], out int result))
                    {
                        employee.Age = result;
                    }
                    else
                    {
                        employee.Email = inputArgs[4];
                    }
                }

                if (inputArgs.Length == 6)
                {
                    int age = int.Parse(inputArgs[5]);
                    employee.Email = inputArgs[4];
                    employee.Age = age;
                }

                employees.Add(employee);
            }

            var topDepart = employees.GroupBy(x => x.Department)
                .ToDictionary(x => x.Key, y => y.Select(s => s))
                .OrderByDescending(x => x.Value.Average(s => s.Salary))
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {topDepart.Key}");
            foreach (var employee in topDepart.Value.OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
            }
        }
    }
}
