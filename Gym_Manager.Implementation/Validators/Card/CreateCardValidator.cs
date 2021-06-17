using FluentValidation;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Validators.Card
{
    public class CreateCardValidator : AbstractValidator<CardDto>
    {

        public CreateCardValidator(GymManagerContext context)
        {

            RuleFor(x => JsonConvert.SerializeObject(x.ExpiresAt)).NotEmpty().DependentRules(() =>
            {
                RuleFor(x => x.ExpiresAt).GreaterThanOrEqualTo(DateTime.Now.AddMonths(1));
            });
            RuleFor(x => x.MembershipId).NotEmpty().DependentRules(() =>
            {
                RuleFor(x => x.MembershipId)
                .Must(y => context.Memberships.Any(m => m.Id == y))
                .WithMessage("Membership doesnt exist");
            });
        }
    }
}
