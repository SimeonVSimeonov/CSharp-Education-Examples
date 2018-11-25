namespace P04GenericSwapMethodInteger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var boxes = new List<Box<int>>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int data = int.Parse(Console.ReadLine());
                boxes.Add(new Box<int>(data));
            }

            int[] indices = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Swap(boxes, indices[0], indices[1]);

            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }

        private static void Swap<T>(IList<Box<T>> list, int index1, int index2)
        {
            Box<T> temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
