using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Core.ViewModels
{
    public class ManagerDto
    {
        //first name, last name, list of EmployeeDtos that he/she is in charge of and their count
        public ManagerDto()
        {
            this.ManagedEmployees = new List<EmployeeDto>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<EmployeeDto> ManagedEmployees { get; set; }
    }
}
