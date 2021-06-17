using Gym_Management.Application.Exceptions;
using Gym_Manager.Application.Commands.Card;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Commands.Card
{
    public class EFDeleteCardCommand : IDeleteCardCommand
    {
        private readonly GymManagerContext _context;

        public EFDeleteCardCommand(GymManagerContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFDeleteCard;

        public string Name => "Deleting Card using EF";

        public void Execute(int request)
        {
            var card = _context.Cards.Find(request);
            if(card == null)
            {
                throw new EntityNotFoundException(request,typeof(CardDto));
            }
            card.IsDeleted = true;
            card.IsActive = false;
            card.DeletedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
