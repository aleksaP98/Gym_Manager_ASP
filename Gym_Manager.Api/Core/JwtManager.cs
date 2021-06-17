using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Gym_Manager.DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Api.Core
{
    public class JwtManager
    {
        private readonly GymManagerContext _context;
        private readonly string _issuer;
        private readonly string _secretKey;


        public JwtManager(GymManagerContext context, string issuer, string secretKey)
        {
            _context = context;
            _issuer = issuer;
            _secretKey = secretKey;
        }

        public string MakeToken(string email, string authentification)
        {
            var user = _context.Users.Include(x => x.UserUseCases).Include(x => x.Card)
                .FirstOrDefault(x => x.Email == email && x.Card.Authentification == authentification);
            var trainer = _context.Trainers.Include(x => x.TrainerUseCases).Include(x => x.Card)
                .FirstOrDefault(x => x.Email == email && x.Card.Authentification == authentification);

            if (user == null && trainer ==null)
            {
                return null;
            }
            var actor = new JWTActor();
            if (user != null)
            {
                actor.Id = user.Id;
                actor.AllowedUseCases = user.UserUseCases.Select(x => x.UseCaseId);
                actor.Identity = user.Card.Authentification;
            }
            else
            {
                actor.Id = trainer.Id;
                actor.AllowedUseCases = trainer.TrainerUseCases.Select(x => x.UseCaseId);
                actor.Identity = trainer.Card.Authentification;
            }
            

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String, _issuer),
                new Claim(JwtRegisteredClaimNames.Iss, "asp_api", ClaimValueTypes.String, _issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, _issuer),
                new Claim("ActorData", JsonConvert.SerializeObject(actor), ClaimValueTypes.String, _issuer)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddSeconds(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
