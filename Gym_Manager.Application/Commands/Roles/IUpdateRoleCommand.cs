using Gym_Manager.Application.Data_Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Application.Commands.Roles
{
    public interface IUpdateRoleCommand : ICommand<RoleDto>
    {
    }
}
