using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.Application.Queries;
using Gym_Manager.Application.Queries.Role;
using Gym_Manager.Application.Searches;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Queries.Role
{
    public class EFGetRolesQuery : IGetRolesQuery
    {
        private readonly GymManagerContext _context;

        public EFGetRolesQuery(GymManagerContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFGetRoles;

        public string Name => "Getting Roles using EF";

        public PagedResponse<RoleDto> Execute(RoleSearch search)
        {
            var query = _context.Roles.AsQueryable();
            if(!string.IsNullOrEmpty(search.Name)||
                !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }
            var skipCount = search.PerPage * (search.Page - 1);
            return new PagedResponse<RoleDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new RoleDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
            };
        }
    }
}
