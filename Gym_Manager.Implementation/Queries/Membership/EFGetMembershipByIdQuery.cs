using AutoMapper;
using Gym_Management.Application.Exceptions;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.Application.Queries;
using Gym_Manager.Application.Queries.Membership;
using Gym_Manager.Application.Searches;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Queries.Membership
{
    public class EFGetMembershipByIdQuery : IGetMembershipByIdQuery
    {
        private readonly GymManagerContext _context;

        public EFGetMembershipByIdQuery(GymManagerContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFGetMembershipById;

        public string Name => "Getting Membership by id using EF";

        public MembershipDto Execute(int search)
        {
            var membership = _context.Memberships.Find(search);
            if (membership == null)
            {
                throw new EntityNotFoundException(search, typeof(MembershipDto));
            }
            return new MembershipDto
            {
                Name = membership.Name,
                Price = membership.Price,
                GymMembership = membership.GymMembership,
                FreePersonalTrainings = membership.FreePersonalTrainings,
                MobileApp = membership.MobileApp,
                PersonalizedCard = membership.PersonalizedCard,
                ProgressTracker = membership.ProgressTracker
            };
        }
    }
}
