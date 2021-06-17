using Gym_Management.Application.Exceptions;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.Application.Queries.PersonalTraining;
using Gym_Manager.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Queries.PersonalTraining
{
    public class EFGetPersonalTrainingByIdQuery : IGetPersonalTrainingByIdQuery
    {
        private readonly GymManagerContext _context;

        public EFGetPersonalTrainingByIdQuery(GymManagerContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFGetPersonalTrainingById;

        public string Name => "Getting Personal Training by id using EF";

        public PersonalTrainingDto Execute(int search)
        {
            var pt = _context.PersonalTrainings.Include(x => x.User).Include(x => x.Trainer).Where(x => x.Id == search).First();
            if(pt == null)
            {
                throw new EntityNotFoundException(search,typeof(PersonalTrainingDto));
            }
            return new PersonalTrainingDto
            {
                Price = pt.Price,
                TrainingStart = pt.TrainingStart,
                User = new UserDto
                {
                    FirstName = pt.User.FirstName,
                    LastName = pt.User.LastName,
                    Email = pt.User.Email
                },
                Trainer = new TrainerDto
                {
                    FirstName = pt.Trainer.FirstName,
                    LastName = pt.Trainer.LastName,
                    Email = pt.Trainer.Email
                }
            };
        }
    }
}
