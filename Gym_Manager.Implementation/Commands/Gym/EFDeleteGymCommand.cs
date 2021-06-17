using Gym_Management.Application.Exceptions;
using Gym_Manager.Application.Commands.Gym;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Commands.Gym
{
    public class EFDeleteGymCommand : IDeleteGymCommand
    {
        private readonly GymManagerContext _context;

        public EFDeleteGymCommand(GymManagerContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFDeleteGym;

        public string Name => "Deleting Gym using EF";

        public void Execute(int request)
        {
            var gym = _context.Gyms.Find(request);
            if(gym == null)
            {
                throw new EntityNotFoundException(request,typeof(GymDto));
            }
            gym.IsActive = false;
            gym.IsDeleted = true;
            gym.DeletedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
