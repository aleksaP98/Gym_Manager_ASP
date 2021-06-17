using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Application.Data_Transfer
{
    public class PersonalTrainingDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TrainerId { get; set; }
        public decimal Price { get; set; }
        public DateTime TrainingStart { get; set; }
        public virtual UserDto User { get; set; }
        public virtual TrainerDto Trainer { get; set; }

    }
}
