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
    public class EFGetMembershipsQuery : IGetMembershipsQuery
    {
        private readonly GymManagerContext _context;

        public EFGetMembershipsQuery(GymManagerContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFGetMemberships;

        public string Name => "Getting Memberships using EF";

        public PagedResponse<MembershipDto> Execute(MembershipSearch search)
        {
            var query = _context.Memberships.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) ||
                !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }
            if (search.Price > 0)
            {
                query = query.Where(x => x.Price <= search.Price);
            }
            if (search.PersonalizedCard)
            {
                query = query.Where(x => x.PersonalizedCard == true);
            }
            if (search.MobileApp)
            {
                query = query.Where(x => x.MobileApp == true);
            }
            if (search.FreePersonalTrainings)
            {
                query = query.Where(x => x.FreePersonalTrainings == true);
            }
            if (search.ProgressTracker)
            {
                query = query.Where(x => x.PersonalizedCard == true);
            }
            var skipCount = search.PerPage * (search.Page - 1);
            return new PagedResponse<MembershipDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new MembershipDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    FreePersonalTrainings = x.FreePersonalTrainings,
                    GymMembership  = x.GymMembership,
                    PersonalizedCard = x.PersonalizedCard,
                    MobileApp = x.MobileApp,
                    ProgressTracker = x.ProgressTracker
                })
            };
        }
    }
}
