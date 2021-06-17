using Gym_Management.Application.Exceptions;
using Gym_Manager.Application.Commands.UseCase;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Commands.UseCase
{
    public class EFDeleteUserUseCaseCommand : IDeleteUserUseCaseCommand
    {
        private readonly GymManagerContext _context;

        public EFDeleteUserUseCaseCommand(GymManagerContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFDeleteUserUseCase;

        public string Name => "Deleting User Use Case using EF";

        
        public void Execute(int request)
        {
            var useCase = _context.UserUseCases.Find(request);
            if (useCase == null)
            {
                throw new EntityNotFoundException(request, typeof(UserUseCaseDto));
            }
            useCase.IsActive = false;
            useCase.IsDeleted = true;
            useCase.DeletedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
