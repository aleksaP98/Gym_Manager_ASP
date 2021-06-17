using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.Application.Queries;
using Gym_Manager.Application.Queries.User;
using Gym_Manager.Application.Searches;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Queries.User
{
    public class EFGetUsersQuery : IGetUsersQuery
    {
        private readonly GymManagerContext _context;

        public EFGetUsersQuery(GymManagerContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFGetUsers;

        public string Name => "Getting Users using EF";

        public PagedResponse<UserDto> Execute(UserSearch search)
        {
            var query = _context.Users.AsQueryable();
            if(!string.IsNullOrEmpty(search.FirstName)||
                !string.IsNullOrWhiteSpace(search.FirstName))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(search.FirstName.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.LastName) ||
                !string.IsNullOrWhiteSpace(search.LastName))
            {
                query = query.Where(x => x.LastName.ToLower().Contains(search.LastName.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.Address) ||
                !string.IsNullOrWhiteSpace(search.Address))
            {
                query = query.Where(x => x.Address.ToLower().Contains(search.Address.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.Email) ||
                !string.IsNullOrWhiteSpace(search.Email))
            {
                query = query.Where(x => x.Email.ToLower().Contains(search.Email.ToLower()));
            }
            if(search.Height > 50)
            {
                query = query.Where(x => x.Height >= search.Height);
            }
            if (search.Weight > 30)
            {
                query = query.Where(x => x.Weight >= search.Weight);
            }
            if (search.BodyFatPercent > 0 && search.BodyFatPercent <= 100)
            {
                query = query.Where(x => x.BodyFatPercent >= search.BodyFatPercent);
            }
            if (search.BodyMusclePercent > 0 && search.BodyMusclePercent <= 100)
            {
                query = query.Where(x => x.BodyMusclePercent >= search.BodyMusclePercent);
            }
            if (search.Age > 15)
            {
                query = query.Where(x => x.Age >= search.Age);
            }
            if (search.Gender == Domain.Gender.Female || search.Gender == Domain.Gender.Male)
            {
                query = query.Where(x => x.Gender == search.Gender);
            }
            var skipCount = search.PerPage * (search.Page - 1);
            return new PagedResponse<UserDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new UserDto
                {
                    Address = x.Address,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    Gender = x.Gender,
                    BodyFatPercent = x.BodyFatPercent,
                    BodyMusclePercent = x.BodyMusclePercent,
                    Weight = x.Weight,
                    Height = x.Height,
                    Email = x.Email,
                    Card = new CardDto
                    {
                        Authentification = x.Card.Authentification,
                        ExpiresAt = x.Card.ExpiresAt,
                        RenewedAt = x.Card.RenewedAt
                    }
                })
            };
            
        }
        
    }
}
