using Gym_Manager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Application.Data_Transfer
{
    public class UserDto : PersonDto
    {
        public int RoleId { get; set; }
        public virtual RoleDto Role { get; set; }
        public virtual IEnumerable<GymUserDto> Gyms { get; set; }
    }
    
}
