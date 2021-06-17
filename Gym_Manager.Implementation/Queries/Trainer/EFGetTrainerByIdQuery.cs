using Gym_Management.Application.Exceptions;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.Application.Queries.Trainer;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Queries.Trainer
{
    public class EFGetTrainerByIdQuery : IGetTrainerByIdQuery
    {
        private readonly GymManagerContext _context;

        public EFGetTrainerByIdQuery(GymManagerContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFGetTrainerById;

        public string Name => "Getting Trainer by id using EF";

        public TrainerDto Execute(int search)
        {
            var trainer = _context.Trainers.Find(search);
            if (trainer == null)
            {
                throw new EntityNotFoundException(search, typeof(TrainerDto));
            }
            return new TrainerDto
            {
                Address = trainer.Address,
                FirstName = trainer.FirstName,
                LastName = trainer.LastName,
                Age = trainer.Age,
                Gender = trainer.Gender,
                BodyFatPercent = trainer.BodyFatPercent,
                BodyMusclePercent = trainer.BodyMusclePercent,
                Weight = trainer.Weight,
                Height = trainer.Height,
                Email = trainer.Email,
                Gym = new GymDto
                {
                    Address = trainer.Gym.Address,
                    Name = trainer.Gym.Name,
                    Description = trainer.Gym.Description
                }
            };
        }
    }
}
