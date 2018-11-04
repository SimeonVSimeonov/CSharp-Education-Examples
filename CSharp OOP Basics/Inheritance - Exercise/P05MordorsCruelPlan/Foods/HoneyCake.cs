using System;
using System.Collections.Generic;
using System.Text;

namespace P05MordorsCruelPlan.Foods
{
    public class HoneyCake : Food
    {
        private const int hapiness = 5;

        public HoneyCake() 
            : base(hapiness)
        {

        }
    }
}
