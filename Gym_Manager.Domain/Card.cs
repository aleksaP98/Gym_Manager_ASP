using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Domain
{
    public class Card : Entity
    {
        public string Authentification { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime? RenewedAt { get; set; }
        public int MembershipId { get; set; }
        public virtual Membership Membership { get; set; }
        public virtual User User { get; set; }
        public virtual Trainer Trainer{ get; set; }


    }
}
