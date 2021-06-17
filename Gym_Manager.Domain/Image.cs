using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Domain
{
    public class Image : Entity
    {
        public string Src { get; set; }
        public virtual ICollection<GymImage> GymImages { get; set; } = new HashSet<GymImage>();
    }
}
