using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000_Days_After_Birth
{
    class Program
    {
        static void Main(string[] args)
        {
            string myDate = Console.ReadLine();

            DateTime answer = DateTime.ParseExact(myDate, "dd-MM-yyyy", null);

            Console.WriteLine(answer.AddDays(999).ToString("dd-MM-yyyy"));
        }
    }
}
