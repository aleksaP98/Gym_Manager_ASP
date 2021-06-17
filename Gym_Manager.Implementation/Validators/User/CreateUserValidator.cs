using FluentValidation;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using Gym_Manager.Implementation.Validators.Gym;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Validators.User
{
    public class CreateUserValidator : AbstractValidator<UserDto>
    {
        public CreateUserValidator(GymManagerContext context)
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
            RuleFor(x => x.CardId).NotEmpty().DependentRules(() =>
            {
                RuleFor(x => x.CardId).Must(y => context.Cards.Any(c => c.Id == y))
                .WithMessage("Card doesnt exist").DependentRules(() => {
                    RuleFor(x => x.CardId).Must((dto, y) => !context.Users.Any(u => u.CardId == y && u.Id != dto.Id))
                    .WithMessage("Card already in use").DependentRules(() => {
                        RuleFor(x => x.CardId).Must(y => context.Memberships.Where(m => m.Name == "Admin Pack").FirstOrDefault() == context.Cards.Find(y).Membership)
                        .When(x => x.RoleId == 1)
                        .WithMessage("Card is not valid for a admin");
                        RuleFor(x => x.CardId).Must(y => context.Memberships.Where(m => m.Name != "Admin Pack" && m.Name != "Trainer Pack" && m.Id == context.Cards.Find(y).MembershipId).FirstOrDefault() == context.Cards.Find(y).Membership)
                        .When(x => x.RoleId == 2)
                        .WithMessage("Card is not valid for a user");
                    });
                });
            });
            RuleFor(x => x.RoleId).NotEmpty().DependentRules(() =>
            {
                RuleFor(x => x.RoleId).Must(y => context.Roles.Any(c => c.Id == y))
                .WithMessage("Role doesnt exist");
            });
            RuleFor(x => x.Email).NotEmpty().DependentRules(() =>
            {
                RuleFor(x => x.Email).Must(y => !context.Users.Any(u => u.Email == y)).WithMessage("Email already exists");
            });
            RuleFor(x => x.Gyms).NotEmpty().When(x => x.RoleId == 2).DependentRules(() =>{
                RuleForEach(x => x.Gyms).SetValidator(new GymUserValidator(context));
            });
            RuleFor(x => x.Gender).NotEmpty().DependentRules(() =>{
                RuleFor(x => x.Gender).IsInEnum().WithMessage("Invalid gender");
            });
            
        }
    }
}
