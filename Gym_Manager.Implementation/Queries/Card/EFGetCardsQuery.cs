using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.Application.Queries;
using Gym_Manager.Application.Queries.Card;
using Gym_Manager.Application.Searches;
using Gym_Manager.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Queries.Card
{
    public class EFGetCardsQuery : IGetCardsQuery
    {
        private readonly GymManagerContext _context;

        public EFGetCardsQuery(GymManagerContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFGetCards;

        public string Name => "Getting Cards using EF";

        public PagedResponse<CardDto> Execute(CardSearch search)
        {
            var query = _context.Cards.AsQueryable();
            if (!string.IsNullOrEmpty(search.Authentification) ||
                !string.IsNullOrWhiteSpace(search.Authentification))
            {
                query = query.Where(x => x.Authentification.Contains(search.Authentification));
            }
            if (search.ExpiresAt != null)
            {
                query = query.Where(x => x.ExpiresAt.Date == search.ExpiresAt.Value);
            }
            if (search.RenewedAt != null)
            {
                query = query.Where(x => x.RenewedAt.Value == search.RenewedAt.Value);
            }
            if (search.MembershipId > 0)
            {
                query = query.Where(x => x.MembershipId == search.MembershipId);
            }
            var skipCount = search.PerPage * (search.Page - 1);
            return new PagedResponse<CardDto>()
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new CardDto
                {
                    Id = x.Id,
                    Authentification = x.Authentification,
                    ExpiresAt = x.ExpiresAt,
                    RenewedAt = x.RenewedAt
                    
                })
            };
        
        }
    }
}

