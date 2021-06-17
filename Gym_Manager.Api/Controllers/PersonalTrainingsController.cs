using Gym_Manager.Application.Commands.PersonalTraining;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.Application.Queries.PersonalTraining;
using Gym_Manager.Application.Searches;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalTrainingsController : ControllerBase
    {
        // GET: api/<PersonalTrainingsController>
        [HttpGet]
        public IActionResult Get([FromQuery] PersonalTrainingSearch search,
            [FromServices] IGetPersonalTrainingsQuery query)
        {
            return Ok(query.Execute(search));
        }

        // GET api/<PersonalTrainingsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,[FromServices] IGetPersonalTrainingByIdQuery query)
        {
            return Ok(query.Execute(id));
        }

        // POST api/<PersonalTrainingsController>
        [HttpPost]
        public IActionResult Post([FromBody] PersonalTrainingDto dto,
            [FromServices] ICreatePersonalTrainingCommand command)
        {
            command.Execute(dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<PersonalTrainingsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PersonalTrainingDto dto,
            [FromServices] IUpdatePersonalTrainingCommand command)
        {
            dto.Id = id;
            command.Execute(dto);
            return NoContent();
        }

        // DELETE api/<PersonalTrainingsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeletePersonalTrainingCommand command)
        {
            command.Execute(id);
            return NoContent();
        }
    }
}
