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
            string token;
            try
            {
                token = jwtAuthenticationManager.Authenticate(userCredentials.Email, userCredentials.Password);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                });
            }
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
