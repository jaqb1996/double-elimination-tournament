using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentWebApi.Models
{
    public class Match
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PositionNumber { get; set; }
        public DateTime? Date { get; set; }
        public int? CourtNumber { get; set; }
        public Tournament Tournament { get; set; }
        public int? FirstTeamScore { get; set; }
        public int? SecondTeamScore { get; set; }
        public Team FirstTeam { get; set; }
        public Team SecondTeam { get; set; }
    }
}
