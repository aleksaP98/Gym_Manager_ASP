using Bogus;
using Gym_Manager.DataAccess;
using Gym_Manager.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gym_Manager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedersController : ControllerBase
    {
        private readonly GymManagerContext _context;

        public SeedersController(GymManagerContext context)
        {
            _context = context;
        }

        // POST api/<SeedersController>
        [HttpPost]
        public IActionResult Post()
        {
            var fakeGyms = new Faker<Gym>();
            fakeGyms.RuleFor(x => x.Address, y => y.Address.StreetAddress());
            fakeGyms.RuleFor(x => x.Description, y => y.Hacker.Phrase());
            fakeGyms.RuleFor(x => x.Name, y => y.Company.CompanyName() + " Gym");

            var gyms = fakeGyms.Generate(10);

            var fakeGymImages = new Faker<GymImage>();
            fakeGymImages.RuleFor(x => x.Gym, y => y.PickRandom(gyms));


            var fakeImages = new Faker<Image>();
            fakeImages.RuleFor(x => x.Src, y => y.Image.PicsumUrl());
            fakeImages.RuleFor(x => x.GymImages, y => fakeGymImages.Generate(5));

            var images = fakeImages.Generate(20);

            var memberships = new List<Membership>
            {
                new Membership
                {
                    Name = "Standard Pack",
                    Price = 9.99m,
                    GymMembership = true,
                    PersonalizedCard = true,
                    MobileApp = false,
                    ProgressTracker = false,
                    FreePersonalTrainings = false
                },
                new Membership
                {
                    Name = "Premium Pack",
                    Price = 19.99m,
                    GymMembership = true,
                    PersonalizedCard = true,
                    MobileApp = true,
                    ProgressTracker = true,
                    FreePersonalTrainings = false
                },
                new Membership
                {
                    Name = "Pro Pack",
                    Price = 34.99m,
                    GymMembership = true,
                    PersonalizedCard = true,
                    MobileApp = true,
                    ProgressTracker = true,
                    FreePersonalTrainings = true
                }
            };
            var fakeCards = new Faker<Card>();
            fakeCards.RuleFor(x => x.Authentification, GenerateCardAuth());
            fakeCards.RuleFor(x => x.ExpiresAt, y => y.Date.Future());
            fakeCards.RuleFor(x => x.Membership,y =>y.PickRandom(memberships));

            var cards = fakeCards.Generate(30);

            var fakeUsers = new Faker<User>();
            fakeUsers.RuleFor(x => x.FirstName, y => y.Person.FirstName);
            fakeUsers.RuleFor(x => x.LastName, y => y.Person.LastName);
            fakeUsers.RuleFor(x => x.Email, y => y.Internet.Email());
            fakeUsers.RuleFor(x => x.Gender, y => y.PickRandom<Gender>());
            fakeUsers.RuleFor(x => x.Age, y => y.Random.Number(15,100));
            fakeUsers.RuleFor(x => x.Address, y => y.Address.StreetAddress());
            fakeUsers.RuleFor(x => x.Weight, y => y.Random.Float(1,300)); //KG
            fakeUsers.RuleFor(x => x.Height, y => y.Random.Float(1,300)); //CM
            fakeUsers.RuleFor(x => x.Card, y => y.PickRandom(cards));

            var users = fakeUsers.Generate(30);

            var fakeTrainers = new Faker<Trainer>();
            fakeTrainers.RuleFor(x => x.FirstName, y => y.Person.FirstName);
            fakeTrainers.RuleFor(x => x.LastName, y => y.Person.LastName);
            fakeTrainers.RuleFor(x => x.Email, y => y.Internet.Email());
            fakeTrainers.RuleFor(x => x.Gender, y => y.PickRandom<Gender>());
            fakeTrainers.RuleFor(x => x.Age, y => y.Random.Number(15, 100));
            fakeTrainers.RuleFor(x => x.Address, y => y.Address.StreetAddress());
            fakeTrainers.RuleFor(x => x.Weight, y => y.Random.Float(1, 300)); //KG
            fakeTrainers.RuleFor(x => x.Height, y => y.Random.Float(1, 300)); //CM
            fakeTrainers.RuleFor(x => x.Card, y => y.PickRandom(cards));
            fakeTrainers.RuleFor(x => x.Gym, y => y.PickRandom(gyms));

            var trainers = fakeTrainers.Generate(15);

            var fakeGymUsers = new Faker<GymUser>();
            fakeGymUsers.RuleFor(x => x.Gym, y => y.PickRandom(gyms));
            fakeGymUsers.RuleFor(x => x.User, y => y.PickRandom(users));

            var gymUsers = fakeGymUsers.Generate(50);

            _context.Gyms.AddRange(gyms);
            _context.Images.AddRange(images);
            _context.Memberships.AddRange(memberships);
            //_context.Cards.AddRange(cards);
            _context.Users.AddRange(users);
            _context.Trainers.AddRange(trainers);
            _context.GymUsers.AddRange(gymUsers);
            _context.SaveChanges();

            return Ok();
        }
        private string GenerateCardAuth()
        {

            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890!@#".ToCharArray();
            string auth = "";
            var random = new Random();
            for (var i = 0; i < 8; i++)
            {
                auth = auth + characters[random.Next(characters.Length)];
            }
            return auth;
        }
    }
}
