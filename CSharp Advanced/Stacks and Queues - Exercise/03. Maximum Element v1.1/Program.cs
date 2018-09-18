using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var maxElementStack = new Stack<int>();
            maxElementStack.Push(int.MinValue);
            StringBuilder result = new StringBuilder();


            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                switch (input[0])
                {
                    case 1:
                        stack.Push(input[1]);
                        if (input[1] >= maxElementStack.Peek())
                        {
                            maxElementStack.Push(input[1]);
                        }
                        break;
                    case 2:
                        int popped = stack.Pop();
                        if (maxElementStack.Peek() == popped)
                        {
                            maxElementStack.Pop();
                        }
                        break;
                    case 3:
                        result.Append($"{maxElementStack.Peek()}{Environment.NewLine}");
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}
