using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentWebApi.Authentication
{
    public class AuthHelper
    {
        public static string HashPassword(string password)
        {
            var hashed = new PasswordHasher<object?>().HashPassword(null, password);
            return hashed; 
        }
        public static bool VerifyPassword(string password, string passwordHash)
        {
            var passwordVerificationResult = new PasswordHasher<object?>().VerifyHashedPassword(null, passwordHash, password);
            return passwordVerificationResult == PasswordVerificationResult.Success;
        }
    }
}
