using Gym_Manager.Application.Commands.Roles;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.Application.Queries.Role;
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
    public class RolesController : ControllerBase
    {
        // GET: api/<RolesController>
        [HttpGet]
        public IActionResult Get([FromQuery] RoleSearch search,
            [FromServices] IGetRolesQuery query)
        {
            return Ok(query.Execute(search));
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,[FromServices] IGetRoleByIdQuery query)
        {
            return Ok(query.Execute(id));
        }

        // POST api/<RolesController>
        [HttpPost]
        public IActionResult Post([FromBody] RoleDto dto,
            [FromServices] ICreateRoleCommand command)
        {
            command.Execute(dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RoleDto dto,
            [FromServices] IUpdateRoleCommand command)
        {
            dto.Id = id;
            command.Execute(dto);
            return NoContent();
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteRoleCommand command)
        {
            command.Execute(id);
            return NoContent();
        }
    }
}
