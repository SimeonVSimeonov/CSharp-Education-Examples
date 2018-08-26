    using System;
    using System.Linq;
    using System.Text;

    namespace _07._Multiply_big_number
    {
        class Program
        {
            static void Main(string[] args)
            {
                string num1 = Console.ReadLine();
                int num2 = int.Parse(Console.ReadLine());

                if (num2==0)
                {
                    Console.WriteLine("0");
                    return;
                }
                int multipyer = 0;
                int reminder = 0;
                int num = 0;
                StringBuilder sb = new StringBuilder(); 

                for (int i = num1.Length-1; i >=0 ; i--)
                {
                    multipyer = (num1[i] - '0') * num2 + reminder;
                    num = multipyer % 10;
                    if (multipyer>9)
                    {
                        reminder = multipyer / 10;
                }
                else
                {
                    reminder = 0;
                }
                sb.Append(num);
            }
            if (reminder>0)
            {
                sb.Append(reminder);
            }
            Console.WriteLine((sb.ToString().TrimEnd('0').ToCharArray().Reverse().ToArray()));
        }
    }
}
