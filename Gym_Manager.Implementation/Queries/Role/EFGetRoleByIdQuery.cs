using Gym_Management.Application.Exceptions;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.Application.Queries.Role;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Queries.Role
{
    public class EFGetRoleByIdQuery : IGetRoleByIdQuery
    {
        private readonly GymManagerContext _context;

        public EFGetRoleByIdQuery(GymManagerContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFGetRoleById;

        public string Name => "Getting Role By Id using EF"; 

        public RoleDto Execute(int search)
        {
            var role = _context.Roles.Find(search);
            if(role == null)
            {
                throw new EntityNotFoundException(search,typeof(RoleDto));
            }
            return new RoleDto
            {
                Name = role.Name
            };
        }
    }
}
