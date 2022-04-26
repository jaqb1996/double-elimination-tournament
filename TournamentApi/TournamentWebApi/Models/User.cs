using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentWebApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength]
        public string PasswordHash { get; set; }
        public ICollection<Tournament> Tournaments { get; set; }
    }
}
