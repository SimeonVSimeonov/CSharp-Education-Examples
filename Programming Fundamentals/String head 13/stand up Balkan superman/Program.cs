using System;

namespace stand_up_Balkan_superman
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "\"Stand up, stand up, Balkan superman.\"";

            Console.WriteLine("message = {0}", message);
            Console.WriteLine("message.Length = {0}", message.Length);

            for (int i = 0; i < message.Length; i++)

            {

                Console.WriteLine("message[{0}] = {1}", i, message[i]);

            }
        }
    }
}
