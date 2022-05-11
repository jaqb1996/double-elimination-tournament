using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWebApi.Models;

namespace TournamentWebApi.DataAccess
{
    public interface ITournamentRepo
    {
        void CreateTournament(Tournament tournament);
        IEnumerable<Tournament> GetAllTournaments();
        void SaveTeam(Team team);
        void AddMatch(Match match);
        Tournament GetTournament(int id);
        Match GetMatch(int id);
        Match UpdateMatchWithTeam(int tournamentId, int matchPosition, Team team, int teamNewPosition);
        Match UpdateMatchWithScore(int matchId, int firstTeamScore, int secondTeamScore);
        int SaveChanges(); 
    }
}
