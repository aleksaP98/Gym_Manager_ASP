using FluentValidation;
using Gym_Management.Application.Exceptions;
using Gym_Manager.Application.Commands.Card;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using Gym_Manager.Implementation.Validators.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Commands.Card
{
    public class EFUpdateCardCommand : IUpdateCardCommand
    {
        private readonly GymManagerContext _context;
        private readonly UpdateCardValidator _validator;

        public EFUpdateCardCommand(UpdateCardValidator validator, GymManagerContext context)
        {
            _validator = validator;
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFUpdateCard;

        public string Name => "Updating Card using EF";

        public void Execute(CardDto request)
        {
            var card = _context.Cards.Find(request.Id);
            if(card == null)
            {
                throw new EntityNotFoundException(request.Id,typeof(CardDto));
            }
            _validator.ValidateAndThrow(request);
            card.Authentification = request.Authentification;
            card.ExpiresAt = request.ExpiresAt;
            card.RenewedAt = request.RenewedAt;
            card.MembershipId = request.MembershipId;
            _context.SaveChanges();
        }
    }
}
