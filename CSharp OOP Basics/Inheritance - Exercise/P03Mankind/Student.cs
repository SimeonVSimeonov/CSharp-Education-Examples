using System;
using System.Collections.Generic;
using System.Text;

namespace P03Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firsName, string lastName, string facultyNumber) 
            : base(firsName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;

            }
            set
            {
                if (value.Length<5 || value.Length>10|| !isValidFacNumber(value))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNumber = value;

            }
        }

        private bool isValidFacNumber(string value)
        {
            bool isValidFacNumber = true;

            foreach (char ch in value)
            {
                if (!char.IsLetterOrDigit(ch))
                {
                    isValidFacNumber = false;
                }
            }

            return isValidFacNumber;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"First Name: {this.FirsName}")
                .AppendLine($"Last Name: {this.LastName}")
                .AppendLine($"Faculty number: {this.facultyNumber}");

            return stringBuilder.ToString();
        }
    }
}
