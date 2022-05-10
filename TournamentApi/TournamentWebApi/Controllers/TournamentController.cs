using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWebApi.DataAccess;
using TournamentWebApi.Models;
using TournamentWebApi.Models.FromUser;

namespace TournamentWebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentRepo tournamentRepo;
        private readonly IMapper mapper;

        public TournamentController(ITournamentRepo tournamentRepo, IMapper mapper)
        {
            this.tournamentRepo = tournamentRepo;
            this.mapper = mapper;
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Create([FromBody] TournamentFromUser tournamentFromUser)
        {
            // TODO: validate tournament
            var tournament = mapper.Map<Tournament>(tournamentFromUser);
            tournament.UserId = 1; // TODO: Get User id
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
            // TODO: Add saving tournament for 16 teams
            return StatusCode(201);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var tournaments = tournamentRepo.GetAllTournaments();
            return StatusCode(200, tournaments);
        }
    }
}
