using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Application.Data_Transfer
{
    public class GymImageDto
    {
        public int GymId { get; set; }
        public int ImageId { get; set; }
        public virtual ImageDto Image{ get; set; }
        public virtual GymDto Gym { get; set; }
        public virtual List<GymImageDto> GymImages { get; set; }
    }
}
