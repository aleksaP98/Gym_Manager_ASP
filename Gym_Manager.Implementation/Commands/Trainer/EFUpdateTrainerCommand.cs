using FluentValidation;
using Gym_Management.Application.Exceptions;
using Gym_Manager.Application.Commands.Trainer;

using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using Gym_Manager.Implementation.Validators.Trainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Commands.Trainer
{
    public class EFUpdateTrainerCommand : IUpdateTrainerCommand
    {
        private readonly GymManagerContext _context;
        private readonly UpdateTrainerValidator _validator;

        public EFUpdateTrainerCommand(UpdateTrainerValidator validator, GymManagerContext context)
        {
            _validator = validator;
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFUpdateTrainer;

        public string Name => "Updating User using EF";

        public void Execute(TrainerDto request)
        {
            var trainer = _context.Trainers.Find(request.Id);
            
            if (trainer == null)
            {
                throw new  EntityNotFoundException(request.Id,typeof(UserDto));
            }
            
            _validator.ValidateAndThrow(request);


            trainer.Address = request.Address;
            trainer.FirstName = request.FirstName;
            trainer.LastName = request.LastName;
            trainer.Height = request.Height;
            trainer.Weight = request.Weight;
            trainer.Age = request.Age;
            trainer.Gender = request.Gender;
            trainer.GymId = request.GymId;
            trainer.Email = request.Email;
            trainer.BodyFatPercent = request.BodyFatPercent;
            trainer.BodyMusclePercent = request.BodyMusclePercent;
            _context.SaveChanges();
        }
    }
}
