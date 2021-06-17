using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Domain
{
    public class Trainer : Entity
    {
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
        public virtual Card Card { get; set; }
        public int GymId { get; set; }
        public virtual Gym Gym { get; set; }
        public virtual ICollection<TrainerUseCase> TrainerUseCases { get; set; } = new HashSet<TrainerUseCase>();
        public virtual ICollection<PersonalTraining> PersonalTrainings { get; set; } = new HashSet<PersonalTraining>();
    }
}
