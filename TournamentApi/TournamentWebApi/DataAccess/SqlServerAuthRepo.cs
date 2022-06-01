using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentWebApi.DataAccess
{
    public class SqlServerAuthRepo : IAuthRepo
    {
        private readonly TournamentContext tournamentContext;

        public SqlServerAuthRepo(TournamentContext tournamentContext)
        {
            this.tournamentContext = tournamentContext;
        }
        public bool IsEmailCorrect(string email, ref string passwordHash)
        {
            var user = tournamentContext.User.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return false;
            }
            passwordHash = user.PasswordHash;
            return true;
        }
    }
}
