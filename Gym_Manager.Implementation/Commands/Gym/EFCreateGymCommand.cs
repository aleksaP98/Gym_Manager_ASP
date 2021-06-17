using AutoMapper;
using FluentValidation;
using Gym_Manager.Application.Commands.Gym;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using Gym_Manager.Domain;
using Gym_Manager.Implementation.Validators.Gym;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Commands.Gym
{
    public class EFCreateGymCommand : ICreateGymCommand
    {
        private readonly GymManagerContext _context;
        private readonly CreateGymValidator _validator;

        public EFCreateGymCommand(CreateGymValidator validator, GymManagerContext context)
        {
            _validator = validator;
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFCreateGym;

        public string Name => "Creating Gym using EF";

        public void Execute(GymDto request)
        {
            _validator.ValidateAndThrow(request);
            var gym = new Domain.Gym
            {
                Address = request.Address,
                Description = request.Description,
                Name = request.Name
            };
            foreach (var image in request.GymImages)
            {
                gym.GymImages.Add(new GymImage
                {
                    ImageId = image.ImageId
                });
            }
            _context.Gyms.Add(gym);
            _context.SaveChanges();
        }
    }
}
