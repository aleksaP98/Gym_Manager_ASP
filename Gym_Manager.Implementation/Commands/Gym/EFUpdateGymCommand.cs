using FluentValidation;
using Gym_Management.Application.Exceptions;
using Gym_Manager.Application.Commands.Gym;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using Gym_Manager.Implementation.Validators.Gym;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Commands.Gym
{
    public class EFUpdateGymCommand : IUpdateGymCommand
    {
        private readonly GymManagerContext _context;
        private readonly UpdateGymValidator _validator;
        public EFUpdateGymCommand(UpdateGymValidator validator, GymManagerContext context)
        {
            _validator = validator;
            _context = context;
        }
        public int Id => (int)UseCasesEnum.EFUpdateGym;

        public string Name => "Updating Gym using EF";

        public void Execute(UpdateGymDto request)
        {
            _validator.ValidateAndThrow(request);
            var gym = _context.Gyms.Include(x => x.GymImages).FirstOrDefault(x => x.Id == request.Id);
            if(gym == null)
            {
                throw new EntityNotFoundException(request.Id,typeof(UpdateGymDto));
            }
            gym.Address = request.Address;
            gym.Description = request.Description;
            gym.Name = request.Name;
            gym.PersonalTrainingPrice = request.PersonalTrainingPrice;
            ChangeGymImages(gym, request);
            _context.SaveChanges();
        }
        private void ChangeGymImages(Domain.Gym gym,UpdateGymDto dto)
        {
            if (dto.GymImages != null)
            {
                _context.GymImages.RemoveRange(gym.GymImages.Where(x => x.ImageId == dto.GymImages.Select(x => x.CurrentImageId).First()));
                var gymImages = new List<Domain.GymImage>();
                foreach (var image in dto.GymImages)
                {
                    gymImages.Add(new Domain.GymImage
                    {
                        GymId = gym.Id,
                        ImageId = image.NewImageId
                    });
                }
                _context.GymImages.AddRange(gymImages);
            }
        }
    }
}
