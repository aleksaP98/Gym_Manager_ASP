using FluentValidation;
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
    public class EFCreateRoleCommand : ICreateRoleCommand
    {
        private readonly GymManagerContext _context;
        private readonly RoleValidator _validator;

        public EFCreateRoleCommand(RoleValidator validator, GymManagerContext context)
        {
            _validator = validator;
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFCreateRole;

        public string Name => "Creating Role using EF";

        public void Execute(RoleDto request)
        {

            _validator.ValidateAndThrow(request);
            _context.Roles.Add(new Domain.Role
            {
                Name = request.Name
            });
            _context.SaveChanges();
        }
    }
}
