using Gym_Management.Application.Exceptions;
using Gym_Manager.Application.Commands.PersonalTraining;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Commands.PersonalTraining
{
    public class EFDeletePersonalTrainingCommand : IDeletePersonalTrainingCommand
    {
        private readonly GymManagerContext _context;

        public EFDeletePersonalTrainingCommand(GymManagerContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFDeletePersonalTraining;

        public string Name => "Deleting Personal Training using EF";

        public void Execute(int request)
        {
            var pt = _context.PersonalTrainings.Find(request);
            if(pt == null)
            {
                throw new EntityNotFoundException(request, typeof(PersonalTrainingDto));
            };
            pt.IsActive = false;
            pt.IsDeleted = true;
            pt.DeletedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
