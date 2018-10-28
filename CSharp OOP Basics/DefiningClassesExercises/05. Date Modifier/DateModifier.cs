using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Date_Modifier
{
    class DateModifier
    {
        public int FindDifference(string dateOne, string dateTwo)
        {
            DateTime first = DateTime.Parse(dateOne);
            DateTime second = DateTime.Parse(dateTwo);

            return Math.Abs((first - second).Days);
        }
    }
}
