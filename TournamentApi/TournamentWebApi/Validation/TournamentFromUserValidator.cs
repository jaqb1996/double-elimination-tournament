using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWebApi.DataAccess;
using TournamentWebApi.Models.FromUser;

namespace TournamentWebApi.Validation
{
    public class TournamentFromUserValidator : AbstractValidator<TournamentFromUser>
    {
        private readonly ITournamentRepo tournamentRepo;

        public TournamentFromUserValidator(ITournamentRepo tournamentRepo)
        {
            this.tournamentRepo = tournamentRepo;
            RuleFor(x => x.Name).Must(BeAvailable)
                .WithMessage("Name of tournament is already taken");
            RuleFor(x => x.NumberOfContestants).Must(n => n == 8 || n == 16)
                .WithMessage("Only 8 or 16 teams are supported");
            RuleFor(x => x.Teams).Must((t, l) => t.NumberOfContestants == l.Count)
                .WithMessage("Number of contestants must be the same as list of teams length");
        }
        private bool BeAvailable(string name)
        {
            var tournament = tournamentRepo.GetTournament(name);
            return tournament is null;
        }
    }
}
