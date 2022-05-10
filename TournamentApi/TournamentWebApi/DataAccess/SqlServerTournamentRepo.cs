using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWebApi.Models;

namespace TournamentWebApi.DataAccess
{
    public class SqlServerTournamentRepo : ITournamentRepo
    {
        private readonly TournamentContext context;

        public SqlServerTournamentRepo(TournamentContext context)
        {
            this.context = context;
        }

        public void AddMatch(Match match)
        {
            context.Match.Add(match);
            context.SaveChanges();
        }

        public void CreateTournament(Tournament tournament)
        {
            context.Tournament.Add(tournament);
            context.SaveChanges();
        }

        public IEnumerable<Tournament> GetAllTournaments()
        {
            return context.Tournament;
        }

        public void SaveTeam(Team team)
        {
            context.Team.Add(team);
            context.SaveChanges();
        }
    }
}
