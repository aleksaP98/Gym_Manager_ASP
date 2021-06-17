using Gym_Management.Application.Exceptions;
using Gym_Manager.Application.Commands.Membership;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Commands.Membership
{
    public class EFDeleteMembershipCommand : IDeleteMembershipCommand
    {
        private readonly GymManagerContext _context;

        public EFDeleteMembershipCommand(GymManagerContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFDeleteMembership;

        public string Name => "Deleting Membership using EF";

        public void Execute(int request)
        {
            var membership = _context.Memberships.Find(request);
            if (membership == null)
            {
                throw new EntityNotFoundException(request,typeof(MembershipDto));
            }
            membership.IsDeleted = true;
            membership.IsActive = false;
            membership.DeletedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
