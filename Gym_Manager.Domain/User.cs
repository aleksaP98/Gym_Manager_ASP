using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Domain
{
    public class User : Entity
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
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public int CardId { get; set; }
        public virtual Card Card { get; set; }
        public virtual ICollection<GymUser> GymUsers { get; set; } = new HashSet<GymUser>();
        public virtual ICollection<UserUseCase> UserUseCases { get; set; } = new HashSet<UserUseCase>();
        public virtual ICollection<PersonalTraining> PersonalTrainings { get; set; } = new HashSet<PersonalTraining>();
    }
    
}
