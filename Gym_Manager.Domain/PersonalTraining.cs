using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Domain
{
    public class PersonalTraining : Entity
    {
        public int UserId { get; set; }
        public int TrainerId { get; set; }
        public virtual User User { get; set; }
        public virtual Trainer Trainer { get; set; }
        public DateTime TrainingStart { get; set; }
        public decimal Price { get; set; }

    }
}
