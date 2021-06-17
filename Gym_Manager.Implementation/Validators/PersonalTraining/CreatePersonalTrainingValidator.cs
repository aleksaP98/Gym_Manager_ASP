using FluentValidation;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Validators.PersonalTraining
{
    public class CreatePersonalTrainingValidator : AbstractValidator<PersonalTrainingDto>
    {
        public CreatePersonalTrainingValidator(GymManagerContext context)
        {
            RuleFor(x => x.UserId).NotEmpty().DependentRules(() =>
            {
                RuleFor(x => x.UserId).Must(y => context.Users.Any(u => u.Id == y))
                .WithMessage("User doesnt exist");
                RuleFor(x => x.Price).Equal(0).When(x => context.Users.Where(y => y.Id == x.UserId).Select(c => c.Card.Membership.FreePersonalTrainings).First())
                .WithMessage("Users with free personal trainings must have 0 as price");
                RuleFor(x => x.Price).NotEmpty().When(x => !context.Users.Where(y => y.Id == x.UserId).Select(c => c.Card.Membership.FreePersonalTrainings).First())
                .DependentRules(() =>
                {
                    RuleFor(x => x.Price).Must(y => context.Gyms.Any(g => g.PersonalTrainingPrice == y))
                    .WithMessage("Price doesnt exist in any Gym");
                });
            });
            RuleFor(x => x.TrainerId).NotEmpty().DependentRules(() =>
            {
                RuleFor(x => x.TrainerId).Must(y => context.Trainers.Any(u => u.Id == y))
                .WithMessage("Trainer doesnt exist");
            });

            RuleFor(x => x.TrainingStart).NotEmpty().DependentRules(() =>
            {
                RuleFor(x => x.TrainingStart).GreaterThan(DateTime.Today);
            });
        }
    }
}
