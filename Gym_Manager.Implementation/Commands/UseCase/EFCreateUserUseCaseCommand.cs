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
    public class EFCreateUserUseCaseCommand : ICreateUserUseCaseCommand
    {
        private readonly GymManagerContext _context;
        private readonly UserUseCaseValidator _validator;

        public EFCreateUserUseCaseCommand(GymManagerContext context, UserUseCaseValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => (int)UseCasesEnum.EFCreateUserUseCase;

        public string Name => "Creating User Use Case using EF";

        public void Execute(UserUseCaseDto request)
        {
            _validator.ValidateAndThrow(request);
            _context.UserUseCases.Add(new Domain.UserUseCase
            {
                UserId = request.UserId,
                UseCaseId = request.UseCaseId
            });
            _context.SaveChanges();
        }
    }
}
