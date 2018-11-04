using System;
using System.Collections;

namespace ProgrArrayListExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            list.Add("Hello!");
            list.Add(5);
            list.Add(3.14159);
            list.Add(DateTime.Now);

            for (int i = 0; i < list.Count; i++)
            {
                object value = list[i];
                Console.WriteLine("Index={0}; Value={1}\n", i, value);
            }
        }
    }
}
