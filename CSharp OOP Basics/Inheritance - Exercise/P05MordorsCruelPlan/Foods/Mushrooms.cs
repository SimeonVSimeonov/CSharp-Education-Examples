using System;
using System.Collections.Generic;
using System.Text;

namespace P05MordorsCruelPlan.Foods
{
    public class Mushrooms : Food
    {
        private const int hapiness = -10;

        public Mushrooms()
            : base(hapiness)
        {

        }
    }
}
