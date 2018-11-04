using System;
using System.Linq;

namespace P04Telephony
{
    public class Validate
    {
        public static void PhoneNumber(string number)
        {
            bool allNumbers = number.All(char.IsNumber);

            if (!allNumbers)
            {
                throw new ArgumentException("Invalid number!");
            }
        }

        public static void Website(string website)
        {
            bool holdNumber = website.Any(char.IsNumber);

            if (holdNumber)
            {
                throw new ArgumentException("Invalid URL!");
            }
        }
    }
}
