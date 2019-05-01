using System;
using System.Net;
using System.Text;

namespace _02.ValidateURL
{
    public class StartUp
    {
        public static void Main()
        {
            var urlInput = Console.ReadLine();
            var decodedUrl = WebUtility.UrlDecode(urlInput);

            try
            {
                var parsedUrl = new Uri(decodedUrl);
                
                if (string.IsNullOrWhiteSpace(parsedUrl.Scheme) ||
                    string.IsNullOrWhiteSpace(parsedUrl.Host) ||
                    string.IsNullOrWhiteSpace(parsedUrl.LocalPath) ||
                    !parsedUrl.IsDefaultPort)
                {
                    throw new ArgumentException("Invalid URL");
                }

                var sb = new StringBuilder();
                sb.AppendLine($"Protocol: {parsedUrl.Scheme}")
                    .AppendLine($"Host: {parsedUrl.Host}")
                    .AppendLine($"Port: {parsedUrl.Port}")
                    .AppendLine($"Path: {parsedUrl.LocalPath}");

                if (!string.IsNullOrWhiteSpace(parsedUrl.Query))
                {
                    sb.AppendLine($"Query: {parsedUrl.Query.Substring(1)}");
                }

                if (!string.IsNullOrWhiteSpace(parsedUrl.Fragment))
                {
                    sb.AppendLine($"Fragment: {parsedUrl.Fragment.Substring(1)}");
                }
                ;
                Console.WriteLine(sb.ToString().Trim());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid URL");

            }
        }
    }
}
