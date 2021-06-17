using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Application.Queries.Role
{
    public interface IGetRolesQuery : IQuery<RoleSearch,PagedResponse<RoleDto>>
    {
    }
}
