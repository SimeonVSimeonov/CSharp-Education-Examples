using System;
using System.Collections.Generic;
using System.Text;

namespace P05MordorsCruelPlan.Foods
{
    public abstract class Food
    {
        public Food(int hapiness)
        {
            this.Hapiness = hapiness;
        }

        public int Hapiness { get; } 
    }
}
