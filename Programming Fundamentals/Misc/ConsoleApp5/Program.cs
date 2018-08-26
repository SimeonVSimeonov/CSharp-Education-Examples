using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //var names = new List<string>();
            //names.Add("pesho");
            //names.Add("ivan");
            //names.Add("gosho");
            //names.Add("maria");
            //names.Reverse();
            //names.RemoveAt(1);
            //Console.WriteLine(string.Join(" ",names));
            //foreach (var x in names)
            //{
            //    Console.WriteLine(x);
            //}



            //int count = int.Parse(Console.ReadLine());

            //List<int> number = new List<int>();
            //for (int i = 0; i < count; i++)
            //{
            //    number.Add(int.Parse(Console.ReadLine()));
            //}


            //string val = Console.ReadLine();

            //List<string> items = val.Split(' ').ToList();
            //List<int> nums = new List<int>();
            //for (int i = 0; i < items.Count; i++)
            //{
            //    nums.Add(int.Parse(items[i]));
            //}
            //var item = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            //Console.WriteLine(string.Join(" ",item));


            //List<string> items = new List<string>() {"zero","one","two","three","four","five"};
            //for (int index = 0; index < items.Count; index++)
            //{
            //    Console.WriteLine("{0}  ---->  {1}",index,items[index]);
            //}


            //List<string> items = new List<string>() { "zero", "one", "two", "three", "four", "five" };
            //items.Sort();items.Reverse();
            //Console.WriteLine(string.Join("; ", items));

            List<int> numbers = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();
            foreach (var number in numbers.Distinct().OrderBy(x => x))
                Console.WriteLine(string.Join(" -> ",
                    number,
                    numbers.Count(x => x == number)));


        }
    }
}
