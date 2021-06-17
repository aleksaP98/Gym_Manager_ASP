using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.Application.Queries;
using Gym_Manager.Application.Queries.PersonalTraining;
using Gym_Manager.Application.Searches;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Queries.PersonalTraining
{
    public class EFGetPersonalTrainingsQuery : IGetPersonalTrainingsQuery
    {
        private readonly GymManagerContext _context;

        public EFGetPersonalTrainingsQuery(GymManagerContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFGetPersonalTrainings;

        public string Name => "Getting Personal Trainings using EF";

        public PagedResponse<PersonalTrainingDto> Execute(PersonalTrainingSearch search)
        {
            var query = _context.PersonalTrainings.AsQueryable();
            if (search.Price > 0)
            {
                query = query.Where(x => x.Price >= search.Price);
            }
            var skipCount = search.PerPage * (search.Page - 1);
            return new PagedResponse<PersonalTrainingDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new PersonalTrainingDto
                {
                    Id = x.Id,
                    Price = x.Price,
                    TrainingStart = x.TrainingStart
                })
            };
        }
    }
}
