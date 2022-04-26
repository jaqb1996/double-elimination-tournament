using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentWebApi.Models.FromUser
{
    public class TournamentFromUser
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public int NumberOfContestants { get; set; }
        public List<TeamFromUser> Teams { get; set; }
    }
}
