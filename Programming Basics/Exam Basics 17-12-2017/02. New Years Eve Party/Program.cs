using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.New_Years_Eve_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int guests = int.Parse(Console.ReadLine());
            int ivanoviBudget = int.Parse(Console.ReadLine());

            double couvertPrice = 0;
            double remainsMoney = 0;
            double moneyFireworks = 0;
            double moneyDonation = 0;
            double noRemainsMoney = 0;

            couvertPrice = guests * 20;

            if (couvertPrice<ivanoviBudget)
            {
                remainsMoney = ivanoviBudget - couvertPrice;
                moneyFireworks = remainsMoney * 0.40;
                moneyDonation = remainsMoney - moneyFireworks;
                Console.WriteLine("Yes! {0:0} lv are for fireworks and {1:0} lv are for donation."
                    ,moneyFireworks,moneyDonation);
            }
            else
            {
                noRemainsMoney = couvertPrice - ivanoviBudget;
                Console.WriteLine("They won't have enough money to pay the covert. They will need {0:0} lv more.",noRemainsMoney);
            }



        }
    }
}
