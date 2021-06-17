using FluentValidation;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Validators.Image
{
    public class UpdateGymImageValidator : AbstractValidator<UpdateGymImageDto>
    {
        public UpdateGymImageValidator(GymManagerContext context)
        {
            RuleFor(x => x.NewImageId).Must(x => context.Images.Any(i => i.Id == x)).WithMessage("Image doesnt exist"); ;
        }
    }
}
