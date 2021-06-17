using FluentValidation;
using Gym_Management.Application.Exceptions;
using Gym_Manager.Application.Commands.Roles;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using Gym_Manager.Implementation.Validators.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Commands.Roles
{
    public class EFUpdateRoleCommand : IUpdateRoleCommand
    {
        private readonly GymManagerContext _context;
        private readonly RoleValidator _validator;

        public EFUpdateRoleCommand(RoleValidator validator, GymManagerContext context)
        {
            _validator = validator;
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFUpdateRole;

        public string Name => "Updating Role using EF";

        public void Execute(RoleDto request)
        {
            var role = _context.Roles.Find(request.Id);
            if(role == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(RoleDto));
            }
            _validator.ValidateAndThrow(request);
            role.Name = request.Name;
            _context.SaveChanges();
        }
    }
}
