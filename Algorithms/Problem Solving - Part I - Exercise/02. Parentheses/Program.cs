using System;
using System.Collections.Generic;
using System.Text;

namespace _02._Parentheses
{
    class Program
    {
        static void Main()
        {
           
            int n = int.Parse(Console.ReadLine());
            int open = n;
            int close = n;
            Stack<char> stack = new Stack<char>();
            var sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                stack.Push('(');
                open--;
                sb.Append('(');
            }
            for (int i = 0; i < n; i++)
            {
                stack.Push(')');
                close--;
                sb.Append(')');
            }

            for (int i = 0; i < n; i++)
            {
                stack.Pop();
                close++;
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
