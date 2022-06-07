using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWebApi.DataAccess;
using TournamentWebApi.Models.FromUser;

namespace TournamentWebApi.Validation
{
    public class UserRegistrationDataValidator : AbstractValidator<UserRegistrationData>
    {
        private readonly IUserRepo userRepo;

        public UserRegistrationDataValidator(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
            RuleFor(x => x.Email).MaximumLength(450);
            RuleFor(x => x.Password).MinimumLength(3);
            RuleFor(x => x.PasswordConfirmation).Must((x, passwordConfirmation) =>
            {
                return x.Password == passwordConfirmation;
            }).WithMessage("Password confirmation must be the same as password");
            RuleFor(x => x.Email).Must(BeAvailable)
                .WithMessage("Email is already taken");
        }
        private bool BeAvailable(string email)
        {
            var user = userRepo.GetUserFromEmail(email);
            return user is null;
        }
    }
}
