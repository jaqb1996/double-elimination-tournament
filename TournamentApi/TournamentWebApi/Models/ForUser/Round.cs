using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentWebApi.Models.ForUser
{
    public class Round
    {
        public int RoundNumber { get; set; }
        public IList<MatchForUser> Matches { get; set; } = new List<MatchForUser>();
    }
}
