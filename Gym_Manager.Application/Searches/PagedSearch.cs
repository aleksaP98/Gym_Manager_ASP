using System;
using System.Collections.Generic;
using System.Text;

namespace Gym_Manager.Application.Searches
{
    public abstract class PagedSearch
    {
        public int PerPage { get; set; } = 2;
        public int Page { get; set; } = 1;
    }
}
