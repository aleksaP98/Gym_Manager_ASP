using FluentValidation;
using Gym_Manager.Application.Data_Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Validators.Membership
{
    public class MembershipValidator : AbstractValidator<MembershipDto>
    {
        public MembershipValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            //RuleFor(x => x.Price).GreaterThan(0);  Cena moze da bude 0 zbog Admin i Trenera koji imaju besplatnu clanarinu
        }
    }
}
