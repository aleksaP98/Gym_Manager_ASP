using FluentValidation;
using Gym_Manager.Application.Commands.Gym;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using Gym_Manager.Domain;
using Gym_Manager.Implementation.Validators.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Commands.Gym
{
    public class EFAddImagesToGymCommand : IAddImagesToGymCommand
    {
        private readonly GymManagerContext _context;
        private readonly ImageValidator _validator;

        public EFAddImagesToGymCommand(ImageValidator validator, GymManagerContext context)
        {
            _validator = validator;
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFAddImageToGym;

        public string Name => "Adding Images to Gym using EF";

        public void Execute(GymImageDto request)
        {

            foreach(var image in request.GymImages)
            {
                _validator.ValidateAndThrow(image);
            }
            var gymImages = new List<GymImage>();
            foreach(var image in request.GymImages)
            {
                gymImages.Add(new GymImage
                {
                    GymId = request.GymId,
                    ImageId = image.ImageId
                });
            }
            _context.GymImages.AddRange(gymImages);
            _context.SaveChanges();
            
            
        }
    }
}
