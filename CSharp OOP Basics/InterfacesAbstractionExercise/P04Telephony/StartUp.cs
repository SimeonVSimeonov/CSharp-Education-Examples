using System;

namespace P04Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var phoneNumbers = Console.ReadLine().Split();
            var websites = Console.ReadLine().Split();
            
            Smartphone smartphone = new Smartphone();

            foreach (var number in phoneNumbers)
            {
                try
                {
                    Console.WriteLine(smartphone.Call(number));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var site in websites)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(site));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
