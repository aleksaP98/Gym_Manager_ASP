using AutoMapper;
using FluentValidation;
using Gym_Manager.Application.Commands.Image;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Commands.Image
{
    public class EFUploadImageCommand : IUploadImageCommand
    {
        private readonly GymManagerContext _context;
        public EFUploadImageCommand(GymManagerContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFUploadImage;

        public string Name => "Creating Image using EF";

        public void Execute(string request)
        {
            _context.Images.Add(new Domain.Image
            {
                Src = request
            });
            _context.SaveChanges();
        }
    }
}
