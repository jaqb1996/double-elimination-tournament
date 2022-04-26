using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWebApi.Models;

namespace TournamentWebApi.DataAccess
{
    public class SqlServerUserRepo : IUserRepo
    {
        private readonly TournamentContext tournamentContext;

        public SqlServerUserRepo(TournamentContext tournamentContext)
        {
            this.tournamentContext = tournamentContext;
        }
        public void CreateUser()
        {
            tournamentContext.User.Add(
                new User()
                {
                    Email = "user@email.com",
                    PasswordHash = "12345"
                }
            );
            tournamentContext.SaveChanges();
        }
    }
}
