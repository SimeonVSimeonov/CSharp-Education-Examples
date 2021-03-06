﻿using AutoMapper;
using MyApp.Commands.Contracts;
using MyApp.Core.ViewModels;
using MyApp.Data;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Commands
{
    public class AddEmployeeCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public AddEmployeeCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            //this.context.Database.EnsureDeleted();
            //this.context.Database.EnsureCreated();

            string firstName = inputArgs[0];
            string lastName = inputArgs[1];
            decimal salary = decimal.Parse(inputArgs[2]);

            //TODO validate

            var employee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            this.context.Add(employee);
            this.context.SaveChanges();

            var employeeDto = this.mapper.CreateMappedObject<EmployeeDto>(employee);

            string result = $"Registered successfully: {employeeDto.FirstName} " +
                $"{employeeDto.LastName} - {employeeDto.Salary}!";

            return result;
        }
    }
}
