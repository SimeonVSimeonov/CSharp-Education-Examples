using System;

namespace _18._Different_Integers_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            string message = "";
            bool isFit = false;

            try
            {
                sbyte num = sbyte.Parse(number);
                message += "* sbyte\r\n";
                isFit = true;
            }
            catch
            {
            }
            
            try
            {
                byte num = byte.Parse(number);
                message += "* byte\r\n";
                isFit = true;
            }
            catch 
            {
            }

            try
            {
                short num = short.Parse(number);
                message += "* short\r\n";
                isFit = true;
            }
            catch
            {
            }

            try
            {
                ushort num = ushort.Parse(number);
                message += "* ushort\r\n";
                isFit = true;
            }
            catch
            {
            }

            try
            {
                int num = int.Parse(number);
                message += "* int\r\n";
                isFit = true;
            }
            catch
            {
            }

            try
            {
                uint num = uint.Parse(number);
                message += "* uint\r\n";
                isFit = true;
            }
            catch
            {
            }

            try
            {
                long num = long.Parse(number);
                message += "* long\r\n";
                isFit = true;
            }
            catch
            {
            }

            if (isFit)
            {
                Console.WriteLine($"{number} can fit in:\r\n{message}");
            }
            else
            {
                Console.WriteLine($"{number} can't fit in any type");
            }
        }
    }
}
