using FluentValidation;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Validators.Trainer
{
    public class CreateTrainerValidator : AbstractValidator<TrainerDto>
    {
        public CreateTrainerValidator(GymManagerContext context)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Age).NotEmpty().DependentRules(() =>
            {
                RuleFor(x => x.Age).GreaterThan(15);
            });
            RuleFor(x => x.Height).GreaterThan(50);
            RuleFor(x => x.Weight).GreaterThan(30);
            RuleFor(x => x.BodyFatPercent).GreaterThan(0).LessThan(100);
            RuleFor(x => x.BodyMusclePercent).GreaterThan(0).LessThan(100);
            RuleFor(x => new { x.BodyMusclePercent, x.BodyFatPercent }).Must(x => x.BodyFatPercent + x.BodyMusclePercent < 100).WithMessage("Body Fat Percent + Body Muscle Percent cant be above 100");
            RuleFor(x => x.CardId).NotEmpty().DependentRules(() =>{
                RuleFor(x => x.CardId).Must(y => context.Cards.Any(c => c.Id == y))
                .WithMessage("Card doesnt exist").DependentRules(() => {
                    RuleFor(x => x.CardId).Must((dto, y) => !context.Trainers.Any(u => u.CardId == y && u.Id != dto.Id))
                    .WithMessage("Card already in use").DependentRules(() => {
                        RuleFor(x => x.Card).Must(y => context.Memberships.Where(m => m.Name == "Trainer Pack").FirstOrDefault() == context.Cards.Find(y.Id).Membership)
                        .WithMessage("Card is not valid for a trainer");
                    }); 
                });
            });
            RuleFor(x => x.Email).NotEmpty().DependentRules(() =>
            {
                RuleFor(x => x.Email).Must(y => !context.Trainers.Any(u => u.Email == y)).WithMessage("Email already exists");
            });
            RuleFor(x => x.GymId).NotEmpty().DependentRules(() =>{
                RuleFor(x => x.GymId).Must(y => context.Gyms.Any(c => c.Id == y))
                .WithMessage("Gym doesnt exist");
            });
            RuleFor(x => x.Gender).NotEmpty().DependentRules(() =>{
                RuleFor(x => x.Gender).IsInEnum().WithMessage("Invalid gender");
            });
            
        }
    }
}
