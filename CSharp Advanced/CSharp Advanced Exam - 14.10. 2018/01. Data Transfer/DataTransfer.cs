using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Data_Transfer
{
    class DataTransfer
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            string input = string.Empty;
            string pattern = @"^s:([^\;]+);r:([^\;]+);m--(""[a-zA-Z ]+"")";
            var data = 0;

            for (int i = 0; i < n; i++)
            {
                var printSender = string.Empty;
                var printReciver = string.Empty;
                input = Console.ReadLine();
                MatchCollection matches = Regex.Matches(input, pattern);

                if (matches.Count == 0)
                {
                    continue;
                }
                else
                {
                    var sender = matches[0].Groups[1].Value;
                    var reciever = matches[0].Groups[2].Value;
                    var message = matches[0].Groups[3].Value;

                    foreach (var item in sender)
                    {
                        if (char.IsLetter(item))
                        {
                            printSender += item;
                        }
                        if (char.IsDigit(item))
                        {
                            data += int.Parse(item.ToString());
                        }
                    }
                    foreach (var item in reciever)
                    {
                        if (char.IsLetter(item))
                        {
                            printReciver += item;
                        }
                        if (char.IsDigit(item))
                        {
                            data += int.Parse(item.ToString());
                        }
                    }

                    Console.WriteLine($"{printSender} says {message} to {printReciver}");
                }
                Console.WriteLine($"Total data transferred: {data}MB");
            }
        }
    }
}
