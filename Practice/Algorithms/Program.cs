using System;
using System.Collections.Generic;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var matches = TeamScheduling.GetMatchesFor(new List<Team> { new Team(1), new Team(2), new Team(3), new Team(4), new Team(5), new Team(6), new Team(7) });
            foreach (Match match in matches)
            {
                Console.WriteLine($"{match.Team1.Id} - {match.Team2.Id} - {match.Date.ToShortDateString()}");
            }

            Console.WriteLine("Permutations of 1234:");
            Sets.PermuteSimple("1234");

            Console.WriteLine("Compare abcd with abcd:");
            Console.WriteLine(Strings.CompareNoLib("abcd", "abcd"));
            Console.WriteLine("Compare abcd with abcd:");
            Console.WriteLine(Strings.CompareNoLib("abc", "abcd"));
        }
    }
}
