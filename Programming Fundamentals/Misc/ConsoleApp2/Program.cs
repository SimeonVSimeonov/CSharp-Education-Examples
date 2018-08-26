using System;
using System.Numerics;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] array = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            //Console.WriteLine(array);

            //int n = int.Parse(Console.ReadLine());

            //int[] array = new int[n];

            //for (int i = 0; i < array.Length; i++)
            //{
            //    array[i] = int.Parse(Console.ReadLine());
            //}

            //int first = int.Parse(Console.ReadLine());
            //int second = int.Parse(Console.ReadLine());

            //int bigNum = first;

            //if (second > first)
            //{
            //    bigNum = second;
            //}
            //Console.WriteLine(bigNum);

            //Console.Write("n = ");
            //int n = int.Parse(Console.ReadLine());
            //int num = 1;
            //int sum = 1;
            //Console.Write("The sum is 1");
            //while (num < n)
            //{
            //    num++;
            //    sum += num;
            //    Console.Write(" + " + num);
            //}
            //Console.WriteLine(" = " + sum);

            //int n = int.Parse(Console.ReadLine());
            //decimal fact = 1;

            //while (true)
            //{
            //    if (n<=1)
            //    {
            //        break;
            //    }
            //    fact *= n;
            //    n--;
            //}
            //Console.WriteLine(fact);

            //int n = int.Parse(Console.ReadLine());
            //BigInteger fact = 1;

            //do
            //{
            //    fact *= n;
            //    n--;
            //} while (n > 0);
            //Console.WriteLine(fact);


            //int n = int.Parse(Console.ReadLine());
            //int m = int.Parse(Console.ReadLine());
            //int num = n;
            //long prod = 1;

            //do
            //{
            //    prod *= num;
            //    num++;

            //} while (num<=m);
            //Console.WriteLine(prod);

            //for (int i = 1,sum = 1; i <= 128; i=i*2,sum+=i)
            //{
            //    Console.WriteLine("{0} {1}",i,sum);
            //}

            //int n = int.Parse(Console.ReadLine());
            //int m = int.Parse(Console.ReadLine());

            //decimal result = 1;

            //for (int i = 0; i < m; i++)
            //{
            //    result *= n;
            //}
            //Console.WriteLine(result);

            //for (int small = 1,large = 10; small < large; small++,large--)
            //{
            //    Console.WriteLine("{0} {1}",small,large);
            //}


            //int n = int.Parse(Console.ReadLine());
            //int sum = 0;

            //for (int i = 1; i <= n; i += 2)
            //{

            //    if (i % 7 == 0)
            //    {
            //        continue;
            //    }
            //    sum += i;
            //}
            //Console.WriteLine(sum);

            //int n = int.Parse(Console.ReadLine());

            //for (int row = 1; row <= n; row++)
            //{

            //    for (int col = 1; col <= row; col++)
            //    {
            //        Console.Write(col + " ");
            //    }
            //    Console.WriteLine();
            //}

            //for (int i1 = 1; i1 <= 44; i1++)

            //{

            //    for (int i2 = i1 + 1; i2 <= 45; i2++)

            //    {

            //        for (int i3 = i2 + 1; i3 <= 46; i3++)

            //        {

            //            for (int i4 = i3 + 1; i4 <= 47; i4++)

            //            {

            //                for (int i5 = i4 + 1; i5 <= 48; i5++)

            //                {

            //                    for (int i6 = i5 + 1; i6 <= 49; i6++)

            //                    {

            //                        Console.WriteLine(i1 + " " + i2 + " " +

            //                                 i3 + " " + i4 + " " + i5 + " " + i6);

            //                    }

            //                }

            //            }

            //        }

            //    }

            //}


            int[] arr = new int[5];

            for (int i = 0; i < arr.Length; i++)

            {

                arr[i] = i;

            }
        }
    }
}
