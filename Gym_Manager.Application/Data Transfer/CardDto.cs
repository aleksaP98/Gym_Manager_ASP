using Gym_Manager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Application.Data_Transfer
{
    public class CardDto
    {
        public int Id { get; set; }
        public string Authentification { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime? RenewedAt { get; set; }
        public int MembershipId { get; set; }
        public virtual MembershipDto Membership { get; set; }
        public virtual UserDto User { get; set; }
        public virtual TrainerDto Trainer { get; set; }
    }

}
