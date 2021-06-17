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
    public class UpdatePersonalTrainingValidator : AbstractValidator<PersonalTrainingDto>
    {

        public UpdatePersonalTrainingValidator(GymManagerContext context)
        {
            RuleFor(x => x.TrainerId).Must(y => context.Trainers.Any(t => t.Id == y))
                .WithMessage("Trainer doesnt exist");
            RuleFor(x => x.TrainingStart).GreaterThan(DateTime.Now.AddDays(1).Date)
                .WithMessage("Training must be scheduled 1 day ahead");
        }
    }
}
