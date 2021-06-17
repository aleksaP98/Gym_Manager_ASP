using FluentValidation;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Validators.Gym
{
    public class GymUserValidator : AbstractValidator<GymUserDto>
    {
        public GymUserValidator(GymManagerContext context)
        {
            RuleFor(x => x.GymId).Must(x => context.Gyms.Any(g => g.Id == x)).WithMessage("Gym doesnt exist");
        }
    }
}
