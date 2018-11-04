using System;
using System.Collections.Generic;
using System.Text;

namespace P03Mankind
{
    public class Human
    {
        private string firsName;
        private string lastName;

        public Human(string firsName, string lastName)
        {
            this.FirsName = firsName;
            this.LastName = lastName;
        }

        public string FirsName
        {
            get
            {
                return this.firsName;
            }

            set
            {
                if (char.IsLower(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter!Argument: firstName");
                }

                if (value.Length < 4)
                {
                    throw new ArgumentException("Expected length at least 4 symbols!Argument: firstName");
                }
                
                this.firsName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (char.IsLower(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter!Argument: lastName");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Expected length at least 3 symbols!Argument: lastName");
                }
                

                this.lastName = value;
            }
        }
    }
}
