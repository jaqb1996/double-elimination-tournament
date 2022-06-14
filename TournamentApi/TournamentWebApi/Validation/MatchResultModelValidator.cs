using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWebApi.Models.FromUser;

namespace TournamentWebApi.Validation
{
    public class MatchResultModelValidator : AbstractValidator<MatchResultModel>
    {
        public MatchResultModelValidator()
        {
            RuleFor(x => x.FirstTeamScore).Must(BeGreaterOrLower).WithMessage("One of the results must be greater");
        }
        private bool BeGreaterOrLower(MatchResultModel model, int firstScore)
        {
            int secondScore = model.SecondTeamScore;
            return firstScore > secondScore || secondScore > firstScore;
        }
    }
}
