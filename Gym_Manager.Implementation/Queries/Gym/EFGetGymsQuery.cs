using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.Application.Queries;
using Gym_Manager.Application.Queries.Gym;
using Gym_Manager.Application.Searches;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Queries.Gym
{
    public class EFGetGymsQuery : IGetGymsQuery
    {
        private readonly GymManagerContext _context;

        public EFGetGymsQuery(GymManagerContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFGetGyms;

        public string Name => "Getting Gyms using EF";

        public PagedResponse<GymDto> Execute(GymSearch search)
        {
            var query = _context.Gyms.AsQueryable();
            if(!string.IsNullOrEmpty(search.Address)
                || !string.IsNullOrWhiteSpace(search.Address))
            {
                query = query.Where(x => x.Address.Contains(search.Address));
            }
            if (!string.IsNullOrEmpty(search.Description)
                || !string.IsNullOrWhiteSpace(search.Description))
            {
                query = query.Where(x => x.Description.Contains(search.Description));
            }
            if (!string.IsNullOrEmpty(search.Name)
                || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.Contains(search.Name));
            }
            
            var skipCount = search.PerPage * (search.Page - 1);
            var response = new PagedResponse<GymDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new GymDto
                {
                    Name = x.Name,
                    Address = x.Address,
                    Description = x.Description
                })
            };
            return response;
        }
    }
}
