using FluentValidation;
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
    public class EFCreateCardCommand : ICreateCardCommand
    {
        private readonly GymManagerContext _context;
        private readonly CreateCardValidator _validator;
        private readonly ChechCardAuthValidator _authValidator;

        public EFCreateCardCommand(CreateCardValidator validator, GymManagerContext context, ChechCardAuthValidator authValidator)
        {
            _validator = validator;
            _context = context;
            _authValidator = authValidator;
        }

        public int Id => (int)UseCasesEnum.EFCreateCard;

        public string Name => "Creating Card using EF";

        public void Execute(CardDto request)
        {
            _validator.ValidateAndThrow(request);
            _context.Cards.Add(new Domain.Card
            {
                Authentification = createCardAuthentification(),
                ExpiresAt = request.ExpiresAt,
                MembershipId = request.MembershipId
            });
            _context.SaveChanges();
        }
        private string createCardAuthentification()
        {
            var chars = new List<string>() { "A","B","C","D",
                "E","F","G","H","I","J","K","L","M","O","P","Q","R","S","T","U","V","W","X","Y","Z",
                "1","2","3","4","5","6","7","8","9","0","!","@","#","$"};
            string auth = "";
            var radnom = new Random();
            for(var i = 0; i < 8; i++)
            {
                auth += chars[radnom.Next(chars.Count)];
            }
            if (!_authValidator.Validate(auth).IsValid)
            {
                createCardAuthentification();
            }
            return auth;
            
        }
    }
}
