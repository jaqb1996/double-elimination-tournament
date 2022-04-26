using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentWebApi.Authentication
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string email, string password);
    }
}
