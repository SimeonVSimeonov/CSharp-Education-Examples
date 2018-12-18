using System;

public class StartUp
{
    static void Main(string[] args)
    {
        var stack = new ArrayStack<int>();

        for (int i = 0; i < 10; i++)
        {
            stack.Push(i);
        }

        stack.Pop();
        Console.WriteLine(stack.Pop());
        Console.WriteLine(string.Join(" ", stack.ToArray()));
        Console.WriteLine(string.Join(" ", stack.ToArray()));
    }
}
