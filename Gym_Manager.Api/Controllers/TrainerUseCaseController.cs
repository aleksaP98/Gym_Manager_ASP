using Gym_Manager.Application;
using Gym_Manager.Application.Commands.UseCase;
using Gym_Manager.Application.Data_Transfer;
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
    public class TrainerUseCaseController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public TrainerUseCaseController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // POST api/<TrainerUseCaseController>
        [HttpPost]
        public IActionResult Post([FromBody] TrainerUseCaseDto dto,
            [FromServices] ICreateTrainerUseCaseCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE api/<TrainerUseCaseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteTrainerUseCaseCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
