using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Application.Data_Transfer
{
    public class UpdateGymDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal PersonalTrainingPrice { get; set; }
        public virtual IEnumerable<UpdateGymImageDto> GymImages { get; set; }
        public virtual IEnumerable<TrainerDto> Trainers { get; set; }
        public virtual IEnumerable<GymUserDto> GymUsers { get; set; }
    }
}
