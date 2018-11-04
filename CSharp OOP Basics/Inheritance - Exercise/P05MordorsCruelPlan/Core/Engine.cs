using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using P05MordorsCruelPlan.Factories;
using P05MordorsCruelPlan.Foods;
using P05MordorsCruelPlan.Moods;

namespace P05MordorsCruelPlan.Core
{
    public class Engine
    {
        private FoodFactory foodFactory;
        private MoodFactory moodFactory;
        // private List<Food> foods;

        public Engine()
        {
            this.foodFactory = new FoodFactory();
            this.moodFactory = new MoodFactory();
            //this.foods = new List<Food>();
        }

        public void Run()
        {
            int points = 0;

            string[] input = Console.ReadLine().Split();

            for (int i = 0; i < input.Length; i++)
            {
                string type = input[i];

                Food currentFood = foodFactory.CreateFood(type);
                points += currentFood.Hapiness;
                //foods.Add(currentFood);
            }

            //int points = foods.Sum(x => x.Hapiness);
            Mood mood;

            if (points < -5)
            {
                mood = moodFactory.CreateMood("angry");
            }
            else if (points >= -5 && points < 0)
            {
                mood = moodFactory.CreateMood("sad");
            }
            else if (points >= 1 && points < 15)
            {
                mood = moodFactory.CreateMood("happy");
            }
            else
            {
                mood = moodFactory.CreateMood("javascript");
            }

            Console.WriteLine(points);
            Console.WriteLine(mood.Name);
        }
    }
}
