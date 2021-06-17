using Gym_Manager.Api.Core;
using Gym_Manager.Application.Commands.Image;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gym_Manager.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UploadImageController : ControllerBase
    {
        private readonly GymManagerContext _context;

        public UploadImageController(GymManagerContext context)
        {
            _context = context;
        }

        // POST api/<ImagesController>
        [HttpPost]
        public IActionResult Post([FromForm] UploadImageDto dto,
            [FromServices] IUploadImageCommand command)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(dto.Image.FileName);
            var size = dto.Image.Length / 1000;
            if (extension != ".png" && extension != ".jpeg" && extension != ".jpg")
            {
                return UnprocessableEntity("Invalid file extenstion");
            }
            if (size > 2000)
            {
                return UnprocessableEntity("File must be smaller than 2 MB");
            }
            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                dto.Image.CopyTo(fileStream);
            }
            command.Execute(path);
            return NoContent();
        }

    }
}
