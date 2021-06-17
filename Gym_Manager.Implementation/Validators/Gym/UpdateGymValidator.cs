using FluentValidation;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using Gym_Manager.Implementation.Validators.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Validators.Gym
{
    public class UpdateGymValidator : AbstractValidator<UpdateGymDto>
    {
        private readonly GymManagerContext _context;
        public UpdateGymValidator(GymManagerContext context)
        {
            _context = context;
            RuleFor(x => x.Description).MaximumLength(300);
            RuleForEach(x => x.GymImages).SetValidator(new UpdateGymImageValidator(_context));

        }
    }
}
