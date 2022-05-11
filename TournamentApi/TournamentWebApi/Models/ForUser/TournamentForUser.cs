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
        public MatchForUser FirstSemifinal { get; set; }
        public MatchForUser SecondSemifinal { get; set; }
        public MatchForUser ThirdPlaceMatch { get; set; }
        public MatchForUser Final { get; set; }
    }
}
