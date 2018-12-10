using System;
using System.Linq;


public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(string.Join(" ", Console.ReadLine().Split().OrderBy(w => w).ToList()));
    }
}

