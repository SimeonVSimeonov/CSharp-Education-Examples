namespace P01GenericBoxOfString
{
    using System;

    class StartUp
    {

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string data = Console.ReadLine();
                Box<string> box = new Box<string>(data);

                Console.WriteLine(box);
            }
        }
    }
}
