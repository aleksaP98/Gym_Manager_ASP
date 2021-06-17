using Gym_Manager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Application.Searches
{
    public class CardSearch : PagedSearch
    {
        public string Authentification { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public DateTime? RenewedAt { get; set; }
        public int MembershipId { get; set; }
    }
}
