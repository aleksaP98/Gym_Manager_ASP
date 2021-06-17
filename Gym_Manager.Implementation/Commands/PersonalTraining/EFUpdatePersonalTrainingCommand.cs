using FluentValidation;
using Gym_Management.Application.Exceptions;
using Gym_Manager.Application.Commands.PersonalTraining;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.Application.Email;
using Gym_Manager.DataAccess;
using Gym_Manager.Implementation.Validators.PersonalTraining;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Commands.PersonalTraining
{
    public class EFUpdatePersonalTrainingCommand : IUpdatePersonalTrainingCommand
    {
        private readonly GymManagerContext _context;
        private readonly UpdatePersonalTrainingValidator _validator;
        private readonly IEmailSender _sender;

        public EFUpdatePersonalTrainingCommand(UpdatePersonalTrainingValidator validator, GymManagerContext context, IEmailSender sender)
        {
            _validator = validator;
            _context = context;
            _sender = sender;
        }

        public int Id => (int)UseCasesEnum.EFUpdatePersonalTraining;

        public string Name => "Updating Personal Training using EF";

        public void Execute(PersonalTrainingDto request)
        {
            var pt = _context.PersonalTrainings.Find(request.Id);
            if(pt == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(PersonalTrainingDto));
            }
            _validator.ValidateAndThrow(request);
            pt.TrainerId = request.TrainerId;
            pt.TrainingStart = request.TrainingStart;
            var user = _context.PersonalTrainings.Include(x => x.User).Where(x => x.Id == request.Id).First().User;
            var trainer  = _context.Trainers.Find(request.TrainerId);
            _sender.Send(new SendEmailDto
            {
                Content = "Your Personal Training has been changed - Your trainer is " + trainer.FirstName + " " + trainer.LastName +
                " and you training starts at " + request.TrainingStart.ToString(),
                SendTo = user.Email,
                Subject = "Personal Training Change"
            });
            _context.SaveChanges();
        }
    }
}
