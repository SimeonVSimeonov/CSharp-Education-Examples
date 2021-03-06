﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApp.Commands.Contracts;
using MyApp.Core.ViewModels;
using MyApp.Data;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApp.Commands
{
    public class ManagerInfoCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public ManagerInfoCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            var managerId = int.Parse(inputArgs[0]);

            //TODO validate
            
            Employee manager = this.context.Employees
                .Include(m => m.ManagedEmployees)
                .FirstOrDefault(x => x.Id == managerId);

            var managerDto = this.mapper.CreateMappedObject<ManagerDto>(manager);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{managerDto.FirstName} {managerDto.LastName} | Employees: " +
                $"{managerDto.ManagedEmployees.Count}");
            ;
            foreach (var item in managerDto.ManagedEmployees)
            {
                sb.AppendLine($"- {item.FirstName} {item.LastName} -${item.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
