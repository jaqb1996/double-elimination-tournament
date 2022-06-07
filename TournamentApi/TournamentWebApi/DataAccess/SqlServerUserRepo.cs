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
        public void CreateUser(User user)
        {
            tournamentContext.User.Add(user);
            tournamentContext.SaveChanges();
        }

        public User GetUserFromEmail(string email)
        {
            return tournamentContext.User.SingleOrDefault(u => u.Email == email);
        }
    }
}
