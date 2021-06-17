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
    public class UpdateCardValidator : AbstractValidator<CardDto>
    {
        public UpdateCardValidator(GymManagerContext context)
        {
            RuleFor(x => x.Authentification).NotEmpty().DependentRules(() => {
                RuleFor(x => x.Authentification)
                .Must((dto, auth) => !context.Cards.Any(c => c.Authentification == auth && c.Id != dto.Id))
                .WithMessage("Card Authentification already exists");
            });
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
            RuleFor(x => JsonConvert.SerializeObject(x.RenewedAt)).NotEmpty().DependentRules(() =>
            {
                RuleFor(x => x.RenewedAt).Equal(DateTime.Now.Date);
            });
        }
    }
}
