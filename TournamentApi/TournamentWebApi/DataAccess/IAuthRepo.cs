using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentWebApi.DataAccess
{
    public interface IAuthRepo
    {
        bool IsEmailCorrect(string email, ref string passwordHash);
    }
}
