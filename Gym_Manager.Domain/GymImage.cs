using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Domain
{
    public class GymImage
    {
        public int GymId { get; set; }
        public int ImageId { get; set; }
        public virtual Image Image { get; set; }
        public virtual Gym Gym { get; set; }
    }
}
