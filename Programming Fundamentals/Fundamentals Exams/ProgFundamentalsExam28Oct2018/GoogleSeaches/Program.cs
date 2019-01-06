using System;

namespace GoogleSeaches
{
    class Program
    {
        static void Main(string[] args)
        {
          
            var totalDays = int.Parse(Console.ReadLine());
            var usersCount = int.Parse(Console.ReadLine());
            var moneyPerSearch = decimal.Parse(Console.ReadLine());
            var usereMoney = 0.0m;
            var totalMoney = 0.0m;

            for (int i = 1; i <= usersCount; i++)
            {
                var words = int.Parse(Console.ReadLine());
                if (words > 5)
                {
                    continue;
                }
                else if (words == 1)
                {
                    usereMoney = (moneyPerSearch * 2) * totalDays;
                    if (i % 3 == 0)
                    {
                        usereMoney *= 3;
                    }
                    totalMoney += usereMoney;
                }
                else
                {

                    usereMoney = moneyPerSearch * totalDays;
                    if (i % 3 == 0)
                    {
                        usereMoney *= 3;
                    }

                    totalMoney += usereMoney;
                }

            }

            Console.WriteLine($"Total money earned for {totalDays} days: {totalMoney:F2}");
        }
    }
}
