namespace P03Stack
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                var tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Push":
                        int[] elements = tokens.Skip(1)
                            .Select(x => x.Split(',').First())
                            .Select(int.Parse)
                            .ToArray();
                        stack.Push(elements);
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
