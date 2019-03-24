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
    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public EmployeePersonalInfoCommand(MyAppContext context, Mapper mapper)
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

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"ID: {employeeDto.Id} - {employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary:F2}");
            sb.AppendLine($"Birthday: {employeeDto.Birthday}");
            sb.AppendLine($"Address: {employeeDto.Address}");

            return sb.ToString();
        }
    }
}
