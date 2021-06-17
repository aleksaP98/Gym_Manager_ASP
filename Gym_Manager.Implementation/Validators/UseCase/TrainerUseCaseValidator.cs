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
    public class TrainerUseCaseValidator : AbstractValidator<TrainerUseCaseDto>
    {
        public TrainerUseCaseValidator(GymManagerContext context)
        {
            RuleFor(x => x.TrainerId).NotEmpty().DependentRules(() =>
            {
                RuleFor(x => x.TrainerId).Must(y => context.Trainers.Any(u => u.Id == y))
                .WithMessage("Trainer doesnt exist");
            });
            RuleFor(x => (UseCasesEnum)x.UseCaseId).IsInEnum().WithMessage("Use case doesnt exist");
        }
    }
}
