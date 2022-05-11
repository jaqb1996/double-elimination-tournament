using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWebApi.Models;

namespace TournamentWebApi.DataAccess
{
    public class SqlServerTournamentRepo : ITournamentRepo // TODO: SaveChanges should be called once from the outside 
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

        public Match GetMatch(int id)
        {
            return context.Match
                        .Include(m => m.Tournament)
                        .Include(m => m.FirstTeam)
                        .Include(m => m.SecondTeam)
                        .First(m => m.Id == id);
        }

        public Tournament GetTournament(int id)
        {
            return context.Tournament
                        .Include(t => t.Matches)
                            .ThenInclude(m => m.FirstTeam)
                        .Include(t => t.Matches)
                            .ThenInclude(m => m.SecondTeam)
                        .FirstOrDefault(t => t.Id == id);
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public void SaveTeam(Team team)
        {
            context.Team.Add(team);
            context.SaveChanges();
        }

        public Match UpdateMatchWithScore(int matchId, int firstTeamScore, int secondTeamScore)
        {
            var match = GetMatch(matchId);
            match.FirstTeamScore = firstTeamScore;
            match.SecondTeamScore = secondTeamScore;
            context.SaveChanges();
            return match;
        }

        public Match UpdateMatchWithTeam(int tournamentId, int matchPosition, Team team, int teamNewPosition)
        {
            var match = context.Match.First(m => m.TournamentId == tournamentId && m.PositionNumber == matchPosition);
            if (teamNewPosition == 0)
                match.FirstTeam = team;
            else
                match.SecondTeam = team;
            context.SaveChanges();
            return match;
        }
    }
}
