using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();
            
            var result = new List<string>();

            while (input[0] != "end")
            {
                string command = input[0];

                switch (command)
                {
                    case "Chat":
                        result.Add(input[1]);
                        break;
                    case "Delete":
                        result.Remove(input[1]);
                        break;
                    case "Edit":
                        result.Remove(input[1]);
                        result.Add(input[2]);
                            break;
                    case "Pin":
                        result.Remove(input[1]);
                        result.Add(input[1]);
                        break;
                    case "Spam":
                        var spam = input.Skip(1).ToArray();
                        foreach (var item in spam)
                        {
                            
                            result.Add(item);
                        }
                        break;
                }

                input = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine(string.Join("\n", result));
        }
    }
}
