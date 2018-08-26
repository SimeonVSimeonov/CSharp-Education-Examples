using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine().ToLower();
            int nights = int.Parse(Console.ReadLine());

            decimal studioPrice = 50.00m;
            decimal apartmentPrice = 65.00m;
            decimal studioRent = 0.00m;
            decimal apartmentRent = 0.00m;

            switch (month)
            {
                case "may":
                case "october":
                    studioPrice = 50.00m;
                    apartmentPrice = 65.00m;

                    studioRent = studioPrice * nights;
                    apartmentRent = apartmentPrice * nights;

                    if (nights>14)
                    {
                        studioRent *= 0.70m;
                        apartmentRent *= 0.90m;
                    }
                    else if (nights>7)
                    {
                        studioRent *= 0.95m;
                    }
                    break;
                case "june":
                case "september":
                    studioPrice = 75.20m;
                    apartmentPrice = 68.70m;

                    studioRent = studioPrice * nights;
                    apartmentRent = apartmentPrice * nights;

                    if (nights>14)
                    {
                        studioRent *= 0.80m;
                        apartmentRent *= 0.90m;
                    }
                    break;
                case "july":
                case "august":

                    studioPrice = 76.00m;
                    apartmentPrice = 77.00m;

                    studioRent = studioPrice * nights;
                    apartmentRent = apartmentPrice * nights;

                    if (nights>14)
                    {
                        apartmentRent *= 0.90m;
                    }
                    break;
            }
            string apartmentInfo = string.Format("Apartment: {0} lv.", decimal.Round(apartmentRent, 2));
            string studioInfo = string.Format("Studio: {0} lv.", decimal.Round(studioRent, 2));

            Console.WriteLine(apartmentInfo);
            Console.WriteLine(studioInfo);

        }
    }
}
