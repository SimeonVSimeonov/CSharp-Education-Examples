using System;

namespace _02._Knights_of_Honor
{
    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            Action<string[]> print = names => Console.WriteLine("Sir " + string.Join("\nSir ",names));  

            string[] inputNames = Console.ReadLine()
                .Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries);

            print(inputNames);
        }
    }
}
