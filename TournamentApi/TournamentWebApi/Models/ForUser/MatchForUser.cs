using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentWebApi.Models.ForUser
{
    public class MatchForUser
    {
        public int Id { get; set; }
        public int PositionNumber { get; set; }
        public DateTime? Date { get; set; }
        public int? CourtNumber { get; set; }
        public int? FirstTeamScore { get; set; }
        public int? SecondTeamScore { get; set; }
        public string FirstTeamName { get; set; }
        public string SecondTeamName { get; set; }
    }
}
