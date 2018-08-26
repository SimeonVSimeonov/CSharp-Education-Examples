using System;
using System.IO;
using System.Linq;

namespace _01._Most_Frequent_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] input = File.ReadAllLines("input.txt");
            string[] result = new string[input.Length];

            { 
                for (int i = 0; i < input.Length; i++)
                {
                    int[] numbers = input[i]
                        .Split(' ')
                        .Select(int.Parse)
                        .ToArray();

                    result[i] = MostFrequentInteger(numbers);
                }

                File.WriteAllLines("output.txt", result);
            }          
        }
        static string MostFrequentInteger(int[] numbers)
        {
            int counter = 1;
            int result = numbers[0];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int testCount = 1;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        testCount++;
                    }
                }

                if (testCount > counter)
                {
                    counter = testCount;
                    result = numbers[i];
                }
            }

            return result.ToString();
        }
    }
}
