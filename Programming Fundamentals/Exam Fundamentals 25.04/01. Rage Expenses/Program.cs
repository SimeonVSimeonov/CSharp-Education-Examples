using System;

namespace _01._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            decimal headsetPrice = decimal.Parse(Console.ReadLine());
            decimal mousePrice = decimal.Parse(Console.ReadLine());
            decimal keyboardPrice = decimal.Parse(Console.ReadLine());
            decimal displayPrice = decimal.Parse(Console.ReadLine());                                  
            decimal expenses = 0;
            decimal trashedHeadset = 0;
            decimal trashedMouse = 0;
            decimal trashedKeyboard = 0;
            decimal trashedDisplay = 0;          

            for (int i = 1; i <= lostGamesCount; i++)
            {
                
                decimal headset = 0;
                decimal mouse = 0;
                decimal key = 0;
                decimal display = 0;

                if (i%2==0)
                {
                    trashedHeadset++;
                    if (trashedHeadset % 3 == 0)
                    {
                        trashedKeyboard++;
                        if (trashedKeyboard % 2 == 0)
                        {
                            trashedDisplay++;
                        }
                    }
                }
                if (i%3==0)
                {
                    trashedMouse++;
                }
                
                headset = trashedHeadset * headsetPrice;
                mouse = trashedMouse * mousePrice;
                key = trashedKeyboard * keyboardPrice;
                display = trashedDisplay * displayPrice;
                expenses = mouse + headset + key + display;
            }

            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}
