using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Domain
{
    public class Gym : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal PersonalTrainingPrice { get; set; }
        public virtual ICollection<GymImage> GymImages { get; set; } = new HashSet<GymImage>();
        public virtual ICollection<Trainer> Trainers { get; set; } = new HashSet<Trainer>();
        public virtual ICollection<GymUser> GymUsers { get; set; } = new HashSet<GymUser>();
    }
}
