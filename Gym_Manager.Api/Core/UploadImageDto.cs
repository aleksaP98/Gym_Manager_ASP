using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gym_Manager.Api.Core
{
    public class UploadImageDto
    {
        public IFormFile Image { get; set; }
    }
}
