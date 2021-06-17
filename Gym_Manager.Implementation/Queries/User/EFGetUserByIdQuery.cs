using Gym_Management.Application.Exceptions;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.Application.Queries.User;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Queries.User
{
    public class EFGetUserByIdQuery : IGetUserByIdQuery
    {
        private readonly GymManagerContext _context;

        public EFGetUserByIdQuery(GymManagerContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFGetUserById;

        public string Name => "Getting User by id using EF";

        public UserDto Execute(int search)
        {
            var user = _context.Users.Find(search);
            if(user == null)
            {
                throw new EntityNotFoundException(search,typeof(UserDto));
            }
            return new UserDto
            {
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                Gender = user.Gender,
                BodyFatPercent = user.BodyFatPercent,
                BodyMusclePercent = user.BodyMusclePercent,
                Weight = user.Weight,
                Height = user.Height,
                Email = user.Email
            };
        }
    }
}
