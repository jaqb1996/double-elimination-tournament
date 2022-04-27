using AutoMapper;
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
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo userRepo;
        private readonly IMapper mapper;

        public UserController(IUserRepo userRepo, IMapper mapper)
        {
            this.userRepo = userRepo;
            this.mapper = mapper;
        }
        [Route("[action]")]
        [HttpPost]
        public IActionResult Register([FromBody] UserRegistrationData userData)
        {
            //TODO: validate userData
            var user = mapper.Map<User>(userData);
            userRepo.CreateUser(user);
            return StatusCode(201);
        }
    }
}
