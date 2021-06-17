using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Application.Data_Transfer
{
    public class GymUserDto
    {
        public int GymId { get; set; }
        public int UserId { get; set; }
        public virtual GymDto Gym { get; set; }
        public virtual UserDto User { get; set; }
    }
}
