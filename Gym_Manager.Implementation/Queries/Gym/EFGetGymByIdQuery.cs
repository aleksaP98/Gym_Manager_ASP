using Gym_Management.Application.Exceptions;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.Application.Queries.Gym;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Queries.Gym
{
    public class EFGetGymByIdQuery : IGetGymByIdQuery
    {
        private readonly GymManagerContext _context;

        public EFGetGymByIdQuery(GymManagerContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFGetGymById;

        public string Name => "Getting Gym by id using EF";

        public GymDto Execute(int search)
        {
            var gym = _context.Gyms.Find(search);
            if(gym == null)
            {
                throw new EntityNotFoundException(search,typeof(GymDto));
            }
            return new GymDto
            {
                Address = gym.Address,
                Description = gym.Description,
                Name = gym.Name
            };
        }
    }
}
