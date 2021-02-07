using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;


namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] listOfPeople = Console.ReadLine().Split(", ");
            Dictionary<string, int> dictionaryOfNames = new Dictionary<string, int>();
            foreach (var name in listOfPeople)
            {
                dictionaryOfNames.Add(name, 0);
            }

            string namePattern = @"[\W\d]";
            string numberPattern = @"[\WA-z]";
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end of race")
            {
                string name = Regex.Replace(input, namePattern, "");
                string distance = Regex.Replace(input, numberPattern, "");
                int sumOfDigits = 0;
                foreach (var digit in distance)
                {
                    int currentDigit = int.Parse(digit.ToString());
                    sumOfDigits += currentDigit;
                }
                if (dictionaryOfNames.ContainsKey(name))
                {
                    dictionaryOfNames[name] += sumOfDigits;
                }
            }
            int count = 1;
            foreach (var kvp in dictionaryOfNames.OrderByDescending(x => x.Value))
            {
                string text = count == 1 ? "st" : count == 2 ? "nd" : "rd";
                Console.WriteLine($"{count++}{text} place: {kvp.Key}");
                if (count == 4)
                {
                    break;
                }
            }
        }
    }
}
