using Gym_Manager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Application.Data_Transfer
{
    public class TrainerDto : PersonDto
    {
        public int GymId { get; set; }
        public virtual GymDto Gym { get; set; }
    }
}
