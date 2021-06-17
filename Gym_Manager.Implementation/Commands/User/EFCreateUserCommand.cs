using FluentValidation;
using Gym_Manager.Application.Commands.User;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using Gym_Manager.Implementation.Validators.User;
using Gym_Manager.Implementation.Extenstions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Commands.User
{
    public class EFCreateUserCommand : ICreateUserCommand
    {
        private readonly GymManagerContext _context;
        private readonly CreateUserValidator _validator;

        public EFCreateUserCommand(CreateUserValidator validator, GymManagerContext context)
        {
            _validator = validator;
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFCreateUser;

        public string Name => "Creating User using EF";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);
            var user = new Domain.User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                Age = request.Age,
                Gender = request.Gender,
                BodyFatPercent = request.BodyFatPercent,
                BodyMusclePercent = request.BodyMusclePercent,
                CardId = request.CardId,
                RoleId = request.RoleId,
                Email = request.Email,
                Height = request.Height,
                Weight = request.Weight,
            };
            foreach(var gym in request.Gyms)
            {
                user.GymUsers.Add(new Domain.GymUser
                {
                    GymId = gym.GymId
                });
            };
            user.AddUseCasesForUser();
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
