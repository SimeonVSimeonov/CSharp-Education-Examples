using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            var demons = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            var demonHealts = new SortedDictionary<string, int>();
            var deamonDamages = new SortedDictionary<string, double>();

            var pattern = @"-?\d+\.?\d*";
            var regex = new Regex(pattern);

            foreach (var demon in demons)
            {
                var healt = demon
                    .Where(s => !char.IsDigit(s)
                    && s != '+' && s != '-' && s != '*' && s != '/'
                    && s != '.')
                    .Sum(s => s);

                demonHealts[demon] = healt;

                var matches = regex.Matches(demon);

                var damage = 0.0;

                foreach (Match match in matches)
                {
                    var value = match.Value;
                    damage += double.Parse(value);
                }

                foreach (var symbol in demon)
                {
                    if (symbol=='*')
                    {
                        damage *= 2;
                    }
                    else if (symbol=='/')
                    {
                        damage /= 2;
                    }
                }

                deamonDamages[demon] = damage;
            }

            foreach (var demon in deamonDamages)
            {
                var demonName = demon.Key;
                var demonHealt = demonHealts[demonName];
                var demonDamage = demon.Value;

                Console.WriteLine($"{demonName} - {demonHealt} health, {demonDamage:F2} damage ");
            }
        }
    }
}
