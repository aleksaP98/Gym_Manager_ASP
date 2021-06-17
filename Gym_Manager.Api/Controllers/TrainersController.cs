using Gym_Manager.Application.Commands.Trainer;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.Application.Queries.Trainer;
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
    public class TrainersController : ControllerBase
    {
        // GET: api/<TrainersController>
        [HttpGet]
        public IActionResult Get([FromQuery] TrainerSearch search,
            [FromServices] IGetTrainersQuery query)
        {
            return Ok(query.Execute(search));
        }

        // GET api/<TrainersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,[FromServices] IGetTrainerByIdQuery query)
        {
            return Ok(query.Execute(id));
        }

        // POST api/<TrainersController>
        [HttpPost]
        public IActionResult Post([FromBody] TrainerDto dto,
            [FromServices] ICreateTrainerCommand command)
        {
            command.Execute(dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<TrainersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TrainerDto dto,
            [FromServices] IUpdateTrainerCommand command)
        {
            dto.Id = id;
            command.Execute(dto);
            return NoContent();
        }

        // DELETE api/<TrainersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteTrainerCommand command)
        {
            command.Execute(id);
            return NoContent();
        }
    }
}
