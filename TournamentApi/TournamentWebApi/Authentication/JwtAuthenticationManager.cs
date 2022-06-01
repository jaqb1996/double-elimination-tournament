using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TournamentWebApi.DataAccess;

namespace TournamentWebApi.Authentication
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string key;
        private readonly IAuthRepo authRepo;

        public JwtAuthenticationManager(string key, IAuthRepo authRepo)
        {
            this.key = key;
            this.authRepo = authRepo;
        }
        public string Authenticate(string email, string password)
        {
            string passwordHash = null;
            if (!authRepo.IsEmailCorrect(email, ref passwordHash))
            {
                return null;
            }
            if (!AuthHelper.VerifyPassword(password, passwordHash))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, email)
                }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey),
                        SecurityAlgorithms.HmacSha256Signature
                    )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
