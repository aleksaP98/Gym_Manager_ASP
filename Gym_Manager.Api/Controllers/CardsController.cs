using Gym_Manager.Application;
using Gym_Manager.Application.Commands.Card;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.Application.Queries.Card;
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
    public class CardsController : ControllerBase
    {

        private readonly UseCaseExecutor _executor;

        public CardsController(UseCaseExecutor executor)
        {
            _executor = executor;
        }



        // GET: api/<CardsController>
        [HttpGet]
        public IActionResult Get([FromQuery] CardSearch search,
            [FromServices] IGetCardsQuery query)
        {
            
            return Ok(_executor.ExecuteQuery(query,search));
        }

        // GET api/<CardsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,[FromServices] IGetCardByIdQuery query)
        {
            return Ok(_executor.ExecuteQuery(query,id));
        }

        // POST api/<CardsController>
        [HttpPost]
        public IActionResult Post([FromBody] CardDto dto,
            [FromServices] ICreateCardCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<CardsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CardDto dto,
            [FromServices] IUpdateCardCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<CardsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteCardCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
