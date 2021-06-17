using FluentValidation;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Validators.User
{
    public class UpdateUserValidator : AbstractValidator<UserDto>
    {
        public UpdateUserValidator(GymManagerContext context)
        {
            RuleFor(x => x.FirstName).NotEqual("");
            RuleFor(x => x.LastName).NotEqual("");
            RuleFor(x => x.Address).NotEqual("");
            RuleFor(x => x.Age).GreaterThan(15);
            RuleFor(x => x.Height).GreaterThan(50);
            RuleFor(x => x.Weight).GreaterThan(30);
            RuleFor(x => x.BodyFatPercent).GreaterThan(0).LessThan(100);
            RuleFor(x => x.BodyMusclePercent).GreaterThan(0).LessThan(100);
            RuleFor(x => new { x.BodyMusclePercent, x.BodyFatPercent }).Must(x => x.BodyFatPercent + x.BodyMusclePercent < 100).WithMessage("Body Fat Percent + Body Muscle Percent cant be above 100");
            RuleFor(x => x.Role.Id).Must(y => context.Roles.Any(c => c.Id == y)).WithMessage("Role doesnt exist");
            RuleFor(x => x.Email).Must((dto,y) => !context.Users.Any(u => u.Email == y && u.Id != dto.Id)).WithMessage("Email already exists");
            RuleFor(x => x.Gender).IsInEnum().WithMessage("Invalid gender");
        }
    }
}
