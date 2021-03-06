﻿using AutoMapper;
using MyApp.Commands.Contracts;
using MyApp.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Commands
{
    public class SetManagerCommand : ICommand
    {
        private readonly MyAppContext context;

        public SetManagerCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
        }

        public string Execute(string[] inputArgs)
        {
            int employeeId = int.Parse(inputArgs[0]);
            int managerId = int.Parse(inputArgs[1]);

            var employee = this.context.Employees.Find(employeeId);
            var manager = this.context.Employees.Find(managerId);
            
            //TODO add validation

            employee.Manager = manager;

            this.context.SaveChanges();

            return "Command completed successfully!";
        }
    }
}
