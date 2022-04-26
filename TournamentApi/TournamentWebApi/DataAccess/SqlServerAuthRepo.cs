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
        public bool IsEmailAndPasswordCorrect(string email, string passwordHash)
        {
            var user = tournamentContext.User.FirstOrDefault(u => u.Email == email && u.PasswordHash == passwordHash);
            return user != null;
        }
    }
}
