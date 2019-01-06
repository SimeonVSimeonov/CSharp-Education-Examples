using System;
using System.Collections.Generic;
using System.Linq;

namespace MeTubeStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            var meTubeViews = new Dictionary<string, int>();
            var meTubeLikes = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "stats time")
            {
                if (input.Contains('-'))
                {
                    string[] data = input.Split('-').ToArray();
                    var video = data[0];
                    var views = int.Parse(data[1]);

                    if (!meTubeViews.ContainsKey(video))
                    {
                        meTubeViews.Add(video, views);
                    }
                    else
                    {
                        meTubeViews[video] += views;
                    }

                }
                else if (input.Contains(':'))
                {
                    string[] data = input.Split(':').ToArray();
                    var vote = data[0];
                    var video = data[1];
                    var count = 1;

                    switch (vote)
                    {
                        case "like":
                            if (!meTubeLikes.ContainsKey(video))
                            {
                                meTubeLikes.Add(video, count);
                            }
                            else
                            {
                                meTubeLikes[video] += count;
                            }
                            break;
                        case "dislike":
                            if (!meTubeLikes.ContainsKey(video))
                            {
                                meTubeLikes.Add(video, count);
                            }
                            else
                            {
                                meTubeLikes[video] -= count;
                            }
                           
                            break;
                    }
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            switch (input)
            {
                case "by likes":
                    var val = 0;

                    foreach (var item in meTubeLikes.OrderByDescending(x => x.Value))
                    {
                        Console.WriteLine($"{item.Key} - {(meTubeViews.ContainsKey(item.Key) ? meTubeViews[item.Key] : val)} views - {item.Value} likes");
                    }
                    break;
                case "by views":
                    val = 0;
                    foreach (var item in meTubeViews.OrderByDescending(x => x.Value))
                    {
                        Console.WriteLine($"{item.Key} - {item.Value} views - {(meTubeLikes.ContainsKey(item.Key) ? meTubeLikes[item.Key] : val)} likes");
                    }
                    break;
            }
        }
    }
}
