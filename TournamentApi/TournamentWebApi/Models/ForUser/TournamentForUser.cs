using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentWebApi.Models.ForUser
{
    public class TournamentForUser
    {
        public string Name { get; set; }
        public int NumberOfContestants { get; set; }
        public IList<Round> UpperBracket { get; set; }
        public IList<Round> LowerBracket { get; set; }
        public MatchForUser[] Finals { get; set; } = new MatchForUser[4]; // 4 final matches: 1 semifinal, 2 semifinal, third place match, final 
    }
}
