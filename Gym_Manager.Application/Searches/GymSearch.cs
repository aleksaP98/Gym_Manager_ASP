﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.Application.Searches
{
    public class GymSearch : PagedSearch
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        
    }
}
