using System;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>([A-z]+)<<(\d+\.?\d*)!(\d+)";
            Regex regex = new Regex(pattern);
            string input = string.Empty;
            double sum = 0.00;

            Console.WriteLine($"Bought furniture:");

            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match match = regex.Match(input);

                //>> Sofa << 312.23!3
                //>> TV << 300!5

                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    double price = double.Parse(match.Groups[2].Value);
                    int quantity = int.Parse(match.Groups[3].Value);

                    Console.WriteLine(name);
                    sum += price * quantity;
                }
            }
            Console.WriteLine($"Total money spend: {sum:F2}");
        }
    }
}
