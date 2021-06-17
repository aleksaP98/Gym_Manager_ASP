using Gym_Management.Application.Exceptions;
using Gym_Manager.Application.Commands.User;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Commands.User
{
    public class EFDeleteUserCommand : IDeleteUserCommand
    {
        private readonly GymManagerContext _context;

        public EFDeleteUserCommand(GymManagerContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFDeleteUser;

        public string Name => "Deleting User using EF";

        public void Execute(int request)
        {
            var user = _context.Users.Find(request);
            if(user == null)
            {
                throw new EntityNotFoundException(request, typeof(UserDto));
            }
            user.IsActive = false;
            user.IsDeleted = true;
            user.DeletedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
