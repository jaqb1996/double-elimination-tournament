using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWebApi.Authentication;
using TournamentWebApi.Models.FromUser;

namespace TournamentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        public AuthenticationController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }
        [Route("[action]")]
        [HttpPost]
        public IActionResult Login([FromBody] UserCredentials userCredentials)
        {
            var token = jwtAuthenticationManager.Authenticate(userCredentials.Email, userCredentials.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new
            {
                Token = token
            });
        }
    }
}
