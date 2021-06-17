using FluentValidation;
using Gym_Management.Application.Exceptions;
using Gym_Manager.Application.Commands.Membership;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using Gym_Manager.Implementation.Validators.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Commands.Membership
{
    public class EFUpdateMembershipCommand : IUpdateMembershipCommand
    {
        private readonly GymManagerContext _context;
        private readonly MembershipValidator _validator;

        public EFUpdateMembershipCommand(GymManagerContext context, MembershipValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => (int)UseCasesEnum.EFUpdateMembership;

        public string Name => "Updating Membership using EF";

        public void Execute(MembershipDto request)
        {
            var membership = _context.Memberships.Find(request.Id);
            if(membership == null)
            {
                throw new EntityNotFoundException(request.Id,typeof(MembershipDto));
            }
            _validator.ValidateAndThrow(request);
            
            membership.Name = request.Name;
            membership.Price = request.Price;
            membership.PersonalizedCard = request.PersonalizedCard;
            membership.FreePersonalTrainings = request.FreePersonalTrainings;
            membership.MobileApp = request.MobileApp;
            membership.ProgressTracker = request.ProgressTracker;

            _context.SaveChanges();
        }
    }
}
