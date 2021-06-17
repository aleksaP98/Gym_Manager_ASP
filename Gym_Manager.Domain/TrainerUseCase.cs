using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Domain
{
    public class TrainerUseCase : Entity
    {
        public int TrainerId { get; set; }
        public int UseCaseId { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}
