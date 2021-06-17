using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Application.Data_Transfer
{
    public class UpdateGymImageDto
    {
        public int GymId { get; set; }
        public int CurrentImageId { get; set; }
        public int NewImageId { get; set; }
        public virtual ImageDto CurrentImage { get; set; }
        public virtual ImageDto NewImage { get; set; }
        public virtual GymDto Gym { get; set; }
    }
}
