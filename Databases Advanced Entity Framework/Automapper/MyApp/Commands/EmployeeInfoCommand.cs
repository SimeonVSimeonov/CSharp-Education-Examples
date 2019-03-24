using AutoMapper;
using MyApp.Commands.Contracts;
using MyApp.Core.ViewModels;
using MyApp.Data;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Commands
{
    public class EmployeeInfoCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public EmployeeInfoCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            var employeeId = int.Parse(inputArgs[0]);

            //TODO validate

            Employee employee = this.context.Employees
                .Find(employeeId);

            var employeeDto = this.mapper.CreateMappedObject<EmployeeDto>(employee);

            return $"ID: {employeeId} - {employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary:F2}";
        }
    }
}
