using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWebApi.DataAccess;

namespace TournamentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo userRepo;

        public UserController(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }
        [Route("[action]")]
        [HttpPost]
        public IActionResult Create()
        {
            userRepo.CreateUser();
            return StatusCode(201);
        }
    }
}
