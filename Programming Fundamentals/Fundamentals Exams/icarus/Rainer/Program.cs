using System;
using System.Linq;

namespace Rainer
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] field = new int[input.Length - 1];
            int[] initial = new int[input.Length - 1];
            int rounds = 0;
            for (int i = 0; i < input.Length-1; i++)
            {
                field[i] = input[i];
                initial[i] = input[i];
            }
            int index = input[input.Length - 1];
            while (true)
            {
                for (int i = 0; i < field.Length; i++)
                {
                    field[i]--;
                }
                if (field[index]==0)
                {
                    break;
                }
                for (int i = 0; i <field.Length; i++)
                {
                    if (field[i]==0)
                    {
                        field[i] = initial[i];
                    }
                }
                rounds++;
                index = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(string.Join(" ",field));
            Console.WriteLine(rounds);
        }
    }
}
