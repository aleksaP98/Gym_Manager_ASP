using Gym_Manager.Application.Commands.Gym;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.Application.Queries.Gym;
using Gym_Manager.Application.Searches;
using Gym_Manager.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gym_Manager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymsController : ControllerBase
    {
        private readonly GymManagerContext _context;

        public GymsController(GymManagerContext context)
        {
            _context = context;
        }

        // GET: api/<GymsController>
        [HttpGet]
        public IActionResult Get([FromQuery] GymSearch search,
            [FromServices] IGetGymsQuery query)
        {
            return Ok(query.Execute(search));
        }

        // GET api/<GymsController>/5

        [HttpGet("{id}")]
        public IActionResult Get(int id,[FromServices] IGetGymByIdQuery query)
        {
            return Ok(query.Execute(id));
        }

        // POST api/<GymsController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] GymDto dto,
            [FromServices] ICreateGymCommand command)
        {
            command.Execute(dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<GymsController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateGymDto dto,
            [FromServices] IUpdateGymCommand command)
        {
            dto.Id = id;
            command.Execute(dto);
            return NoContent();
        }
        [HttpPatch("{id}")]
        [Authorize]
        public IActionResult Patch(int id,[FromBody] GymImageDto dto,
            [FromServices] IAddImagesToGymCommand command)
        {
            dto.GymId = id;
            command.Execute(dto);
            return NoContent();
        }

        // DELETE api/<GymsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id,[FromServices] IDeleteGymCommand command)
        {
            command.Execute(id);
            return NoContent();
        }
    }
}
