using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _04._Movie_Time
{
    class MovieTime
    {
        static void Main(string[] args)
        {
            var movieList = new Dictionary<string, Dictionary<string, TimeSpan>>();

            string favoriteGenre = Console.ReadLine();
            string favoriteDuration = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "POPCORN!")
            {
                string[] inputArgs = input.Split('|');

                string movieName = inputArgs[0];
                string genre = inputArgs[1];
                string duration = inputArgs[2];

                TimeSpan time = TimeSpan.Parse(duration, CultureInfo.InvariantCulture);

                if (!movieList.ContainsKey(genre))
                {
                    movieList.Add(genre, new Dictionary<string, TimeSpan>());
                }

                if (!movieList[genre].ContainsKey(movieName))
                {
                    movieList[genre].Add(movieName, time);
                }

                input = Console.ReadLine();

            }

            movieList[favoriteGenre] = movieList[favoriteGenre]
                .OrderBy(x => favoriteDuration == "Short" ? x.Value : -x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var movieKvp in movieList[favoriteGenre])
            {
                Console.WriteLine(movieKvp.Key);
                string wifeCommand = Console.ReadLine();

                if (wifeCommand == "Yes")
                {
                    var totalSeconds = movieList.Values.Sum(x => x.Sum(s => s.Value.TotalSeconds));

                    string timeSpan = TimeSpan.FromSeconds(totalSeconds).ToString(@"hh\:mm\:ss");

                    Console.WriteLine($"We're watching {movieKvp.Key} - {movieKvp.Value}");
                    Console.WriteLine($"Total Playlist Duration: {timeSpan}");
                    return;
                }
            }
        }
    }
}
