using Gym_Management.Application;
using Gym_Manager.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gym_Manager.Api.Core
{
    public class JWTActor : IApplicationActor
    {
        public int Id {get; set;}

        public string Identity { get; set; }

        public IEnumerable<int> AllowedUseCases { get; set; }

        
    }
}
