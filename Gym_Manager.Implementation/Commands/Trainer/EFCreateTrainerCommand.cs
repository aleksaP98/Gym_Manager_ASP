using FluentValidation;
using Gym_Manager.Application.Commands.Trainer;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using Gym_Manager.Implementation.Validators.Trainer;
using Gym_Manager.Implementation.Extenstions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Commands.Trainer
{
    public class EFCreateTrainerCommand : ICreateTrainerCommand
    {
        private readonly GymManagerContext _context;
        private readonly CreateTrainerValidator _validator;

        public EFCreateTrainerCommand(CreateTrainerValidator validator, GymManagerContext context)
        {
            _validator = validator;
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFCreateTrainer;

        public string Name => "Creating Trainer using EF";

        public void Execute(TrainerDto request)
        {

            _validator.ValidateAndThrow(request);
            var trainer = new Domain.Trainer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                Age = request.Age,
                Gender = request.Gender,
                BodyFatPercent = request.BodyFatPercent,
                BodyMusclePercent = request.BodyMusclePercent,
                CardId = request.CardId,
                Email = request.Email,
                Height = request.Height,
                Weight = request.Weight,
                GymId = request.GymId
            };
            trainer.AddUseCasesForTrainer();
            _context.Trainers.Add(trainer);
            _context.SaveChanges();
        }
    }
}
