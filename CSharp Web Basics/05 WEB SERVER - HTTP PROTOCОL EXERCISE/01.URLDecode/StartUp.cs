using System;
using System.Net;

namespace _01.URLDecode
{
    public class StartUp
    {
        public static void Main()
        {
            var url = Console.ReadLine();
            var decodedUrl = WebUtility.UrlDecode(url);
            Console.WriteLine(decodedUrl);
        }
    }
}
