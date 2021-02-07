using System;
using System.Text.RegularExpressions;

namespace Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([a-zA-Z0-9]+\.?\-?\w+)@(\w+\.?\-?\w+\.?\w+?\.\w+)";
            // string pattern = @"([A-z0-9]?\w+\.?\-?\w+)@(\w+\.?\-?\w+\.?\w+?\.\w+)";
            string input = Console.ReadLine();
            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);
            if (match.Success)
            {
                string user = match.Groups[1].Value;
                string host = match.Groups[2].Value;

                Console.WriteLine($"{user}@{host}");
            }
        }
    }
}
