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
    public class CreateGymValidator : AbstractValidator<GymDto>
    {
        private readonly GymManagerContext _context;
        public CreateGymValidator(GymManagerContext context)
        {
            _context = context;
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Description).MaximumLength(300);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.GymImages).NotEmpty().WithMessage("Select at least 1 Image").DependentRules(() =>
            {
                RuleForEach(x => x.GymImages).SetValidator(new ImageValidator(_context));
            });
            
        }
    }
}
