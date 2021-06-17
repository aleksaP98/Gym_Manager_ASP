using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Gym_Manager.Application.Commands.Membership;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using Gym_Manager.Implementation.Validators.Membership;
using Gym_Manager.Domain;

namespace Gym_Manager.Implementation.Commands.Membership
{
    public class EFCreateMembershipCommand : ICreateMembershipCommand
    {
        private readonly GymManagerContext _context;
        private readonly MembershipValidator _validator;

        public EFCreateMembershipCommand(GymManagerContext context, MembershipValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => (int)UseCasesEnum.EFCreateMembership;

        public string Name => "Creating Membership using EF";

        public void Execute(MembershipDto request)
        {
            _validator.ValidateAndThrow(request);
            _context.Memberships.Add(new Domain.Membership
            {
                Name = request.Name,
                Price = request.Price,
                GymMembership = true,
                PersonalizedCard = request.PersonalizedCard,
                FreePersonalTrainings = request.FreePersonalTrainings,
                MobileApp = request.MobileApp,
                ProgressTracker = request.ProgressTracker
            });
            _context.SaveChanges();
        }
    }
}
