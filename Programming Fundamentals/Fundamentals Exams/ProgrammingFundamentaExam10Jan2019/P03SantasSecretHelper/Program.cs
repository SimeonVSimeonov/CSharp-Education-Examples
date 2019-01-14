using System;
using System.Collections.Generic;
using System.Text;

namespace P03SantasSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberSubtract = int.Parse(Console.ReadLine());
            var result = new List<string>();
            string input;
            //StringBuilder str = new StringBuilder();
            char[] vs;

            while ((input = Console.ReadLine())!= "end")
            {
                var words = input.ToCharArray();
                
                foreach (var word in words)
                {
                    //char symb = word - (char)numberSubtract;
                   
                }

                

            }
        }
    }
}
