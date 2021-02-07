using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder keyDecrypted = new StringBuilder();
            string patternKey = @"[STARstar]";
            Regex keyRegex = new Regex(patternKey);
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match keyMatch = keyRegex.Match(input);
                int key = Regex.Matches(input, patternKey).Count;

                for (int k = 0; k < input.Length; k++)
                {
                    char current = (char)(input[k] - key);
                    keyDecrypted.Append(current);
                }

                string patternName = @"@([A-Za-z]+)";
                Regex nameRegex = new Regex(patternName);
                Match nameMatch = nameRegex.Match(keyDecrypted.ToString());
                string planetName = nameMatch.Groups[1].Value;

                string patternPeople = @":(\d+)";
                Regex peopleRegex = new Regex(patternPeople);
                Match peopleMatch = peopleRegex.Match(keyDecrypted.ToString());
                string planetPeople = peopleMatch.Groups[1].Value;

                if (!peopleMatch.Success)
                {
                    keyDecrypted.Clear();
                    continue;
                }
                string patternAttack = @"\!([A-Z])\!";
                Regex attackRegex = new Regex(patternAttack);
                Match attackMatch = attackRegex.Match(keyDecrypted.ToString());
                string planetAttack = attackMatch.Groups[1].Value;

                if (!attackMatch.Success)
                {
                    keyDecrypted.Clear();
                    continue;
                }

                string patternSoldiers = @"->([\d]+)";
                Regex soldiersRegex = new Regex(patternSoldiers);
                Match soldiersMatch = soldiersRegex.Match(keyDecrypted.ToString());
                string planetSoldiers = soldiersMatch.Groups[1].Value;

                if (!soldiersMatch.Success)
                {
                    keyDecrypted.Clear();
                    continue;
                }
                if (planetAttack == "A")
                {
                    attackedPlanets.Add(planetName);
                    attackedPlanets.Sort();
                }
                else if (planetAttack == "D")
                {
                    destroyedPlanets.Add(planetName);
                    destroyedPlanets.Sort();
                }

                keyDecrypted.Clear();
            }
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var aP in attackedPlanets)
            {
                Console.WriteLine($"-> {aP}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var dP in destroyedPlanets)
            {
                Console.WriteLine($"-> {dP}");
            }
        }
    }
}
