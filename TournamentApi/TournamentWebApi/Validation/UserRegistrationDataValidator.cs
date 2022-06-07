using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWebApi.Models.FromUser;

namespace TournamentWebApi.Validation
{
    public class UserRegistrationDataValidator : AbstractValidator<UserRegistrationData>
    {
        public UserRegistrationDataValidator()
        {
            RuleFor(x => x.Email).MaximumLength(450);
            RuleFor(x => x.Password).MinimumLength(3);
            RuleFor(x => x.PasswordConfirmation).Must((x, passwordConfirmation) =>
            {
                return x.Password == passwordConfirmation;
            }).WithMessage("Password confirmation must be the same as password");
        }
    }
}
