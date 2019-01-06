using System;
using System.Collections.Generic;
using System.Linq;

namespace P02KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var lengthSequences = int.Parse(Console.ReadLine());
            var input = string.Empty;
            int index = 0;
            int resultIndex = 0;

            var result = new int[lengthSequences];
            var nums = new int[lengthSequences];


            while ((input = Console.ReadLine()) != "Clone them!")
            {
                index++;
                nums = input.Split(new char[] { '!', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                ;
                int[] param = GetInfo(nums);

                if (IsBetter(param, result))
                {
                    result = nums;
                    resultIndex = index;
                }
                if (resultIndex == 0)
                {
                    result = nums;
                    resultIndex = index;
                }

            }

            Console.WriteLine($"Best DNA sample {resultIndex} with sum: {result.Sum()}.");
            Console.WriteLine(string.Join(" ", result));

        }

        private static bool IsBetter(int[] param, int[] result)
        {
            int[] finalParams = GetInfo(result);
            if (param[0] > finalParams[0])
            {
                return true;
            }
            else if (param[0] == finalParams[0])
            {
                if (param[1] < finalParams[1])
                {
                    return true;
                }
                else if (param[1] == finalParams[1])
                {
                    if (param[2] > finalParams[2])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static int[] GetInfo(int[] nums)
        {
            int sequence = 0;
            int position = 0;
            int sum = nums.Sum();
            int counter = 0;
            int counterMax = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    counter++;

                    if (counter > counterMax)
                    {
                        counterMax = counter;
                        position = i - counter - 1;
                    }
                }
                else
                {
                    counter = 0;
                }
            }
            sequence = counterMax;

            return new int[] { sequence, position, sum };
        }
    }
}
