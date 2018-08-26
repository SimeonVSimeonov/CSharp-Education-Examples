using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            string nOperator = Console.ReadLine();

            double result = 0.0;
            string output = string.Empty;

            if (n2 == 0 && (nOperator.Equals("/") || nOperator.Equals("%")))
            {
                output = string.Format("Cannot divide {0} by zero", n1);
            }
            else if (nOperator.Equals("/"))
            {
                result = n1 / n2;
                output = string.Format("{0} {1} {2} = {3:f2}", n1, nOperator, n2, result);
            }
            else if (nOperator.Equals("%"))
            {
                result = n1 % n2;
                output = string.Format("{0} {1} {2} = {3}", n1, nOperator, n2, result);
            }
            else
            {
                if (nOperator.Equals("+"))
                {
                    result = n1 + n2;
                }
                else if (nOperator.Equals("-"))
                {
                    result = n1 - n2;
                }
                else if (nOperator.Equals("*"))
                {
                    result = n1 * n2;
                }
                output = string.Format("{0} {1} {2} = {3} - {4}",n1,nOperator,n2,result,result%2==0?"even":"odd");
                
                 
                
            }
            Console.WriteLine(output);
        }
    }
}
