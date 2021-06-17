using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Application.Searches
{
    public class TrainerSearch : PagedSearch
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public float? BodyFatPercent { get; set; }
        public float? BodyMusclePercent { get; set; }
        public int CardId { get; set; }
        public virtual CardDto Card { get; set; }
        public int GymId { get; set; }
        public virtual GymDto Gym { get; set; }
    }
}
