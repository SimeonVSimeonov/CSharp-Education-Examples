using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();
            var isBalance = true;

            foreach (var ch in input)
            {
                switch (ch)
                {
                    case '(':
                    case '{':
                    case '[':
                        stack.Push(ch);
                        break;
                    case ')':
                        if (!stack.Any() || stack.Pop() != '(')
                        {
                            isBalance = false;
                        }
                        break;
                    case '}':
                        if (!stack.Any() || stack.Pop() != '{')
                        {
                            isBalance = false;
                        }
                        break;
                    case ']':
                        if (!stack.Any() || stack.Pop() != '[')
                        {
                            isBalance = false;
                        }
                        break;
                    default:
                        break;
                }
            }

            var result = isBalance ? "YES" : "NO";
            Console.WriteLine(result);
        }
    }
}
