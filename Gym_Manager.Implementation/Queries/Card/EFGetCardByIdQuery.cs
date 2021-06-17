using Gym_Management.Application.Exceptions;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.Application.Queries.Card;
using Gym_Manager.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Implementation.Queries.Card
{
    public class EFGetCardByIdQuery : IGetCardByIdQuery
    {
        private readonly GymManagerContext _context;

        public EFGetCardByIdQuery(GymManagerContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCasesEnum.EFGetCardById;

        public string Name => "Getting Card by id using EF";

        public CardDto Execute(int search)
        {
            var card = _context.Cards.Find(search);
            if(card == null)
            {
                throw new EntityNotFoundException(search, typeof(CardDto));
            }
            return new CardDto
            {
                Authentification = card.Authentification,
                ExpiresAt = card.ExpiresAt,
                RenewedAt = card.RenewedAt
            };
        }
    }
}
