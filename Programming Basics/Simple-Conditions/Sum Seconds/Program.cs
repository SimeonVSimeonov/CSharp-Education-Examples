using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            var time1 = double.Parse(Console.ReadLine());
            var time2 = double.Parse(Console.ReadLine());
            var time3 = double.Parse(Console.ReadLine());
            double result = time1 + time2 + time3;
            if (result <= 59)
            {
                if (result < 9)
                {
                    Console.WriteLine("0:0{0}", result);
                }
                else
                {
                    Console.WriteLine("0:{0}", result);
                }
            }
            else if (result <= 119)
            {
                if (result <= 69)
                {
                    Console.WriteLine("1:0{0}", result - 60);
                }
                else
                {
                    Console.WriteLine("1:{0}", result - 60);
                }
            }
            else if (result<=179)
            {
                if (result<=129)
                {
                    Console.WriteLine("2:0{0}", result - 120);
                }
                else
                {
                    Console.WriteLine("2:{0}", result - 120);
                }
            }
                
            }
            
        }
    }

