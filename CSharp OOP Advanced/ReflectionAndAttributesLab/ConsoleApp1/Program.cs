using System;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.LoadFile(@"C:\Users\Simeonoff\Desktop\MyCrazyApp.dll");

            var allTypes = assembly.GetTypes();

            foreach (var currType in allTypes)
            {
                Console.WriteLine(currType.Name);
            }
        }
    }
}
