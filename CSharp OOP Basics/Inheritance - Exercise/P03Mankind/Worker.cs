using System;
using System.Collections.Generic;
using System.Text;

namespace P03Mankind
{
    public class Worker : Human
    {
        private double weekSalary;
    private double workHoursDay;

    public Worker(string firsName, string lastName, double weekSalary, double workHoursDay)
        : base(firsName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursDay = workHoursDay;
    }

    public double WeekSalary
    {
        get
        {
            return this.weekSalary;
        }

        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch!Argument: weekSalary");
            }

            this.weekSalary = value;
        }
    }

    public double WorkHoursDay
    {
        get
        {
            return this.workHoursDay;
        }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch!Argument: workHoursPerDay");
            }

            this.workHoursDay = value;
        }
    }

    private double GetSalaryPerHour()
    {
        return this.weekSalary / (this.workHoursDay * 5);
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"First Name: {this.FirsName}")
            .AppendLine($"Last Name: {this.LastName}")
            .AppendLine($"Week Salary: {this.weekSalary:F2}")
            .AppendLine($"Hours per day: {this.workHoursDay:F2}")
            .AppendLine($"Salary per hour: {GetSalaryPerHour():F2}");

        return stringBuilder.ToString();
    }
}
}
