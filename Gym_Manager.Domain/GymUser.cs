using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Domain
{
    public class GymUser
    {
        public int GymId { get; set; }
        public int UserId { get; set; }
        public virtual Gym Gym { get; set; }
        public virtual User User { get; set; }
    }
}
