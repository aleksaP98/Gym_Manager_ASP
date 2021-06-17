using FluentValidation;
using Gym_Management.Application.Exceptions;
using Gym_Manager.Application.Commands.User;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using Gym_Manager.Implementation.Validators.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Commands.User
{
    public class EFUpdateUserCommand : IUpdateUserCommand
    {
        private readonly GymManagerContext _context;
        private readonly UpdateUserValidator _validator;

        public EFUpdateUserCommand(UpdateUserValidator validator, GymManagerContext context)
        {
            _validator = validator;
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFUpdateUser;

        public string Name => "Updating User using EF";

        public void Execute(UserDto request)
        {
            var user = _context.Users.Find(request.Id);
            
            if (user == null)
            {
                throw new  EntityNotFoundException(request.Id,typeof(UserDto));
            }
            
            _validator.ValidateAndThrow(request);

            
            user.Address = request.Address;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Height = request.Height;
            user.Weight = request.Weight;
            user.Age = request.Age;
            user.Gender = request.Gender;
            user.Email = request.Email;
            user.BodyFatPercent = request.BodyFatPercent;
            user.BodyMusclePercent = request.BodyMusclePercent;
            user.RoleId = request.RoleId;
            _context.SaveChanges();
        }
    }
}
