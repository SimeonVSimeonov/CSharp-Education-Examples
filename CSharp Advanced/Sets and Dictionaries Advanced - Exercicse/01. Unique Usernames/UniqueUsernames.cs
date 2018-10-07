using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    class UniqueUsernames
    {
        static void Main(string[] args)
        {
            var usernames = new HashSet<string>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var username = Console.ReadLine();
                usernames.Add(username);
            }

            foreach (var user in usernames)
            {
                Console.WriteLine(user);
            }
        }
    }
}
