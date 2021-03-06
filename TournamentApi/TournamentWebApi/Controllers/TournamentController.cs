using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TournamentWebApi.DataAccess;
using TournamentWebApi.Models;
using TournamentWebApi.Models.ForUser;
using TournamentWebApi.Models.FromUser;
using TournamentWebApi.TournamentLogic;

namespace TournamentWebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentRepo tournamentRepo;
        private readonly IMapper mapper;
        private readonly IUserRepo userRepo;

        public TournamentController(ITournamentRepo tournamentRepo, IMapper mapper, IUserRepo userRepo)
        {
            this.tournamentRepo = tournamentRepo;
            this.mapper = mapper;
            this.userRepo = userRepo;
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Create([FromBody] TournamentFromUser tournamentFromUser)
        {
            var tournament = mapper.Map<Tournament>(tournamentFromUser);
            tournament.Owner = GetUser();
            tournamentRepo.CreateTournament(tournament);
            // Add tournament teams
            List<Team> teams = mapper.Map<List<TeamFromUser>, List<Team>>(tournamentFromUser.Teams);
            foreach (Team team in teams)
            {
                tournamentRepo.SaveTeam(team);
            }
            if (tournament.NumberOfContestants == 8)
            {
                for (int positionNumber = 1; positionNumber <= 14; positionNumber++) // 14 matches for 8 teams
                {
                    Match match = new()
                    {
                        PositionNumber = positionNumber,
                        Tournament = tournament,
                    };
                    // Fill matches 1-4 with teams 
                    if (positionNumber == 1)
                    {
                        match.FirstTeam = teams[0];
                        match.SecondTeam = teams[7];
                    }
                    else if (positionNumber == 2)
                    {
                        match.FirstTeam = teams[3];
                        match.SecondTeam = teams[4];
                    }
                    else if (positionNumber == 3)
                    {
                        match.FirstTeam = teams[5];
                        match.SecondTeam = teams[2];
                    }
                    else if (positionNumber == 4)
                    {
                        match.FirstTeam = teams[1];
                        match.SecondTeam = teams[6];
                    }
                    tournamentRepo.AddMatch(match);
                }
            }
            else if (tournament.NumberOfContestants == 16)
            {
                for (int positionNumber = 1; positionNumber < 30; positionNumber++) // 30 matches for 16 teams
                {
                    Match match = new()
                    {
                        PositionNumber = positionNumber,
                        Tournament = tournament
                    };
                    // Fill matches 1-8 with teams 
                    if (positionNumber == 1)
                    {
                        match.FirstTeam = teams[0];
                        match.SecondTeam = teams[15];
                    }
                    else if (positionNumber == 2)
                    {
                        match.FirstTeam = teams[7];
                        match.SecondTeam = teams[8];
                    }
                    else if (positionNumber == 3)
                    {
                        match.FirstTeam = teams[3];
                        match.SecondTeam = teams[12];
                    }
                    else if (positionNumber == 4)
                    {
                        match.FirstTeam = teams[11];
                        match.SecondTeam = teams[4];
                    }
                    else if (positionNumber == 5)
                    {
                        match.FirstTeam = teams[10];
                        match.SecondTeam = teams[5];
                    }
                    else if (positionNumber == 6)
                    {
                        match.FirstTeam = teams[13];
                        match.SecondTeam = teams[2];
                    }
                    else if (positionNumber == 7)
                    {
                        match.FirstTeam = teams[6];
                        match.SecondTeam = teams[9];
                    }
                    else if (positionNumber == 8)
                    {
                        match.FirstTeam = teams[14];
                        match.SecondTeam = teams[1];
                    }
                }
            }
            return StatusCode(201);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var tournaments = tournamentRepo.GetAllTournaments();
            return StatusCode(200, tournaments);
        }
        [HttpGet]
        [Route("[action]/{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            var tournament = tournamentRepo.GetTournament(id);
            if (tournament == null)
            {
                return StatusCode(204);
            }
            var tournamentForUser = mapper.Map<TournamentForUser>(tournament);
            Round roundFirstUpperBracket = new() { RoundNumber = 1 };
            Round roundSecondUpperBracket = new() { RoundNumber = 2 };
            Round roundThirdUpperBracket = new() { RoundNumber = 3 }; // for 16 teams
            Round roundFirstLowerBracket = new() { RoundNumber = 1 };
            Round roundSecondLowerBracket = new() { RoundNumber = 2 };
            Round roundThirdLowerBracket = new() { RoundNumber = 3 };
            Round roundFourthLowerBracket = new() { RoundNumber = 4 };
            foreach (Match match in tournament.Matches)
            {
                var matchForUser = mapper.Map<MatchForUser>(match);
                if (tournament.NumberOfContestants == 8)
                {
                    // For 8 teams there are 2 rounds for each bracket + semifinals + finals
                    var positionNumber = matchForUser.PositionNumber;
                    if (positionNumber <= 4)
                    {
                        roundFirstUpperBracket.Matches.Add(matchForUser);
                    }
                    else if (5 <= positionNumber && positionNumber <= 6)
                    {
                        roundSecondUpperBracket.Matches.Add(matchForUser);
                    }
                    else if (11 <= positionNumber && positionNumber <= 12)
                    {
                        roundFirstLowerBracket.Matches.Add(matchForUser);
                    }
                    else if (9 <= positionNumber && positionNumber <= 10)
                    {
                        roundSecondLowerBracket.Matches.Add(matchForUser);
                    }
                    else if (positionNumber == 7)
                    {
                        tournamentForUser.Finals[0] = matchForUser; // 1 semifinal
                    }
                    else if (positionNumber == 8)
                    {
                        tournamentForUser.Finals[1] = matchForUser; // 2 semifinal
                    }
                    else if (positionNumber == 13)
                    {
                        tournamentForUser.Finals[3] = matchForUser; // Final
                    }
                    else if (positionNumber == 14)
                    {
                        tournamentForUser.Finals[2] = matchForUser; // Third place match
                    }
                    else
                    {
                        throw new Exception("Bad position number");
                    }
                }
                else if (tournament.NumberOfContestants == 16) // for 16 teams there are 3 rounds in upper bracket
                {                                              // 4 rounds for lower bracket
                    var positionNumber = matchForUser.PositionNumber;
                    if (positionNumber <= 8)
                    {
                        roundFirstUpperBracket.Matches.Add(matchForUser);
                    }
                    else if (9 <= positionNumber && positionNumber <= 12)
                    {
                        roundSecondUpperBracket.Matches.Add(matchForUser);
                    }
                    else if (13 <= positionNumber && positionNumber <= 14)
                    {
                        roundThirdUpperBracket.Matches.Add(matchForUser);
                    }
                    else if (25 <= positionNumber && positionNumber <= 28)
                    {
                        roundFirstLowerBracket.Matches.Add(matchForUser);
                    }
                    else if (21 <= positionNumber && positionNumber <= 24)
                    {
                        roundSecondLowerBracket.Matches.Add(matchForUser);
                    }
                    else if (19 <= positionNumber && positionNumber <= 20)
                    {
                        roundThirdLowerBracket.Matches.Add(matchForUser);
                    }
                    else if (17 <= positionNumber && positionNumber <= 18)
                    {
                        roundFourthLowerBracket.Matches.Add(matchForUser);
                    }
                    else if (positionNumber == 15)
                    {
                        tournamentForUser.Finals[0] = matchForUser; // 1 semifinal
                    }
                    else if (positionNumber == 16)
                    {
                        tournamentForUser.Finals[1] = matchForUser; // 2 semifinal
                    }
                    else if (positionNumber == 29)
                    {
                        tournamentForUser.Finals[3] = matchForUser; // final
                    }
                    else if (positionNumber == 30)
                    {
                        tournamentForUser.Finals[2] = matchForUser; // 3 place match
                    }
                    else
                    {
                        throw new Exception("Bad position number");
                    }
                }
            }
            if (tournamentForUser.NumberOfContestants == 8)
            {
                tournamentForUser.UpperBracket = new List<Round>
                {
                    roundFirstUpperBracket,
                    roundSecondUpperBracket
                };
                tournamentForUser.LowerBracket = new List<Round>
                {
                    roundFirstLowerBracket,
                    roundSecondLowerBracket
                };
            }
            else if (tournamentForUser.NumberOfContestants == 16)
            {
                tournamentForUser.UpperBracket = new List<Round>
                {
                    roundFirstUpperBracket,
                    roundSecondUpperBracket,
                    roundThirdUpperBracket
                };
                tournamentForUser.LowerBracket = new List<Round>
                {
                    roundFirstLowerBracket,
                    roundSecondLowerBracket,
                    roundThirdLowerBracket,
                    roundFourthLowerBracket
                };
            }
            return StatusCode(200, tournamentForUser);
        }
        [HttpPost]
        [Route("[action]/{matchId}")]
        public IActionResult MatchResult([FromBody] MatchResultModel result, int matchId)
        {
            var match = tournamentRepo.UpdateMatchWithScore(matchId, result.FirstTeamScore, result.SecondTeamScore);
            bool firstTeamWon = match.FirstTeamScore > match.SecondTeamScore;
            Team winner = firstTeamWon ? match.FirstTeam : match.SecondTeam;
            Team looser = firstTeamWon ? match.SecondTeam : match.FirstTeam;
            // Move teams to appropriate places in brackets
            var numberOfTeamsInTournament = match.Tournament.NumberOfContestants;
            var tournamentId = match.TournamentId;
            var positionMatchNumber = match.PositionNumber;
            int? LooserNewMatch = null;
            int? LooserNewPositionInMatch = null;
            int? WinnerNewMatch = null;
            int? WinnerNewPositionInMatch = null;
            if (numberOfTeamsInTournament == 8)
            {
                (LooserNewMatch, LooserNewPositionInMatch,
                 WinnerNewMatch, WinnerNewPositionInMatch) = TeamsBracketMovements.MOVEMENTS_FOR_8_TEAMS[positionMatchNumber];
            }
            else if (numberOfTeamsInTournament == 16)
            {
                (LooserNewMatch, LooserNewPositionInMatch,
                 WinnerNewMatch, WinnerNewPositionInMatch) = TeamsBracketMovements.MOVEMENTS_FOR_16_TEAMS[positionMatchNumber];
            }
            else
            {
                throw new Exception("Unsupported number of teams");
            }
            if (LooserNewMatch != null && LooserNewPositionInMatch != null)
                tournamentRepo.UpdateMatchWithTeam(tournamentId, (int)LooserNewMatch, looser, (int)LooserNewPositionInMatch);
            if (WinnerNewMatch != null && WinnerNewPositionInMatch != null)
                tournamentRepo.UpdateMatchWithTeam(tournamentId, (int)WinnerNewMatch, winner, (int)WinnerNewPositionInMatch);
            return Ok();
        }
        [HttpDelete]
        [Route("[action]/{tournamentId}")]
        public IActionResult Delete(int tournamentId)
        {
            // TODO: Check if tournament belongs to current user
            bool wasFound = tournamentRepo.DeleteTournament(tournamentId);
            if (!wasFound)
                return StatusCode(204);
            tournamentRepo.SaveChanges();
            return StatusCode(200);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult TournamentsForUser()
        {
            var user = GetUser();
            var tournaments = tournamentRepo.GetAllTournamentsForUser(user);
            return StatusCode(200, tournaments);
        }

        private User GetUser()
        {
            var userEmail = User.Claims.First(x => x.Type == ClaimTypes.Name).Value;
            return userRepo.GetUserFromEmail(userEmail);
        }
    }
}
