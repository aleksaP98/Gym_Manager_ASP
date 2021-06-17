using FluentValidation;
using Gym_Manager.Application.Commands.PersonalTraining;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using Gym_Manager.Implementation.Validators.PersonalTraining;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Commands.PersonalTraining
{
    public class EFCreatePersonalTrainingCommand : ICreatePersonalTrainingCommand
    {
        private readonly GymManagerContext _context;
        private readonly CreatePersonalTrainingValidator _validator;
        public EFCreatePersonalTrainingCommand(GymManagerContext context, CreatePersonalTrainingValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => (int)UseCasesEnum.EFCreatePersonalTraining;

        public string Name => "Creating Personal Training using EF";

        public void Execute(PersonalTrainingDto request)
        {
            
            _validator.ValidateAndThrow(request);
            _context.PersonalTrainings.Add(new Domain.PersonalTraining
            {
                Price = request.Price,
                UserId = request.UserId,
                TrainerId = request.TrainerId,
                TrainingStart = request.TrainingStart
            });
            _context.SaveChanges();
        }
    }
}
