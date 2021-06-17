using FluentValidation;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Validators.Card
{
    public class ChechCardAuthValidator : AbstractValidator<string>
    {

        public ChechCardAuthValidator(GymManagerContext context)
        {
            RuleFor(x => x).Must(y => !context.Cards.Any(u => u.Authentification == y));
        }
    }
}
