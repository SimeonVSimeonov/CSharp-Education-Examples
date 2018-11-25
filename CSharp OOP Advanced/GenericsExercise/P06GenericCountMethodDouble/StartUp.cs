namespace P06GenericCountMethodDouble
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Box<double>> boxes = new List<Box<double>>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                double data = double.Parse(Console.ReadLine());
                boxes.Add(new Box<double>(data));
            }

            double element = double.Parse(Console.ReadLine());

            Console.WriteLine(CountGreater(boxes, element));
        }

        private static int CountGreater<T>(IEnumerable<Box<T>> collection, T element)
            where T : IComparable<T>
        {
            int counter = 0;

            foreach (var item in collection)
            {
                if (item.CompareTo(element) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
