using Gym_Management.Application.Exceptions;
using Gym_Manager.Application.Commands.Roles;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Commands.Roles
{
    public class EFDeleteRoleCommand : IDeleteRoleCommand
    {
        private readonly GymManagerContext _context;

        public EFDeleteRoleCommand(GymManagerContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFDeleteRole;

        public string Name => "Deleting Role using EF";

        public void Execute(int request)
        {
            var role = _context.Roles.Find(request);
            if(role == null)
            {
                throw new EntityNotFoundException(request,typeof(RoleDto));
            }
            role.IsActive = false;
            role.IsDeleted = true;
            role.DeletedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
