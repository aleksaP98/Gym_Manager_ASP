using Gym_Manager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Application.Data_Transfer
{
    public class MembershipDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool GymMembership { get; set; }
        public bool PersonalizedCard { get; set; }
        public bool MobileApp { get; set; }
        public bool ProgressTracker { get; set; }
        public bool FreePersonalTrainings { get; set; }
        public virtual ICollection<CardDto> Cards { get; set; }
    }
}
