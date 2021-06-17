using FluentValidation;
using Gym_Manager.Application.Commands.UseCase;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using Gym_Manager.Implementation.Validators.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Commands.UseCase
{
    public class EFCreateTrainerUseCaseCommand : ICreateTrainerUseCaseCommand
    {
        private readonly GymManagerContext _context;
        private readonly TrainerUseCaseValidator _validator;

        public EFCreateTrainerUseCaseCommand(GymManagerContext context, TrainerUseCaseValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => (int)UseCasesEnum.EFCreateTrainerUseCase;

        public string Name => "Creating Trainer Use Case using EF";

        public void Execute(TrainerUseCaseDto request)
        {
            _validator.ValidateAndThrow(request);
            _context.TrainerUseCases.Add(new Domain.TrainerUseCase
            {
                TrainerId = request.TrainerId,
                UseCaseId = request.UseCaseId
            });
            _context.SaveChanges();
        }
    }
}
