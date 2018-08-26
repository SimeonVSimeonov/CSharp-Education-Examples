using System;
using System.Linq;

namespace Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int[] final = new int[lenght];
            int finalIndex = 0;
            int index = 0;
            int[] nums = new int[lenght];

            while (input!="Clone them!")
            {
                index++;
                nums = input.Split(new char[] {'!',' '},StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                int[] parameters = GetInfo(nums);

                if (IsBetter(parameters,final))
                {
                    final = nums;
                    finalIndex = index;
                }
                if (finalIndex==0)
                {
                    final = nums;
                    finalIndex = index;
                }

                input = Console.ReadLine();

            }

            Console.WriteLine($"Best DNA sample {finalIndex} with sum: {final.Sum()}.");
            Console.WriteLine(string.Join(" ",final));
        }

        static bool IsBetter(int[] parameters, int[] final)
        {
            int[] finalParams = GetInfo(final);
            if (parameters[0]>finalParams[0])
            {
                return true;
            }
            else if (parameters[0] == finalParams[0])
            {
                if (parameters[1] < finalParams[1])
                {
                    return true;
                }
                else if (parameters[1] == finalParams[1])
                {
                    if (parameters[2] > finalParams[2])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static int[] GetInfo(int[] nums)
        {
            int sequence = 0;
            int position = 0;
            int sum = nums.Sum();
            int counter = 0;
            int counterMax = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i]==1)
                {
                    counter++;
                    if (counter>counterMax)
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
