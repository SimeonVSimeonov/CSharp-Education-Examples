namespace P02GenericBoxOfInteger
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int data = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(data);

                Console.WriteLine(box);
            }
        }
    }
}
