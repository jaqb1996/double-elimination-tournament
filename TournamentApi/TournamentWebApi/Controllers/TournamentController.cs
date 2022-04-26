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
            var tournament = mapper.Map<Tournament>(tournamentFromUser);
            foreach (var t in tournamentFromUser.Teams)
            {
                Console.WriteLine(t.Name);
            }
            tournament.UserId = 1;
            tournamentRepo.CreateTournament(tournament);
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
