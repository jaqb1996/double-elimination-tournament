using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentWebApi.Models
{
    public class Match
    {
        public enum BracketType
        {
            Upper,
            Lower,
            Semifinal,
            Final
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public int PositionNumber { get; set; }
        [Required]
        public BracketType Bracket { get; set; }
        [Required]
        public int RoundNumber { get; set; }
        public DateTime? Date { get; set; }
        public int? CourtNumber { get; set; }
        public Tournament Tournament { get; set; }
        public int? FirstTeamScore { get; set; }
        public int? SecondTeamScore { get; set; }
        public Team FirstTeam { get; set; }
        public Team SecondTeam { get; set; }
    }
}
