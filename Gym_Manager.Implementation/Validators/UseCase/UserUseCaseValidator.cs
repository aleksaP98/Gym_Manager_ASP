using FluentValidation;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Validators.UseCase
{
    public class UserUseCaseValidator : AbstractValidator<UserUseCaseDto>
    {
        public UserUseCaseValidator(GymManagerContext context)
        {
            RuleFor(x => x.UserId).NotEmpty().DependentRules(() =>
            {
                RuleFor(x => x.UserId).Must(y => context.Users.Any(u => u.Id == y))
                .WithMessage("User doesnt exist");
            });
            RuleFor(x => (UseCasesEnum)x.UseCaseId).IsInEnum().WithMessage("Use case doesnt exist");
        }
    }
}
