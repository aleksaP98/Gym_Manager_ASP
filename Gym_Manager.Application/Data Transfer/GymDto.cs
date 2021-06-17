using Gym_Manager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Application.Data_Transfer
{
    public class GymDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public virtual IEnumerable<GymImageDto> GymImages { get; set; }
        public virtual IEnumerable<TrainerDto> Trainers { get; set; }
        public virtual IEnumerable<GymUserDto> GymUsers { get; set; }
    }
}
