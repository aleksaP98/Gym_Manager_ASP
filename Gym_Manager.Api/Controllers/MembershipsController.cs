using Gym_Manager.Application.Commands.Membership;
using Gym_Manager.Application.Data_Transfer;
using Gym_Manager.Application.Queries.Membership;
using Gym_Manager.Application.Searches;
using Gym_Manager.DataAccess;
using Gym_Manager.Implementation.Validators.Membership;
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
    public class MembershipsController : ControllerBase
    {
        private readonly GymManagerContext _context;

        public MembershipsController(GymManagerContext context)
        {
            _context = context;
        }
        // GET: api/<MembershipsController>
        [HttpGet]
        public IActionResult Get([FromQuery] MembershipSearch search,
            [FromServices] IGetMembershipsQuery query)
        {
            var memberships = query.Execute(search);
            return Ok(memberships);
        }

        // GET api/<MembershipsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,
            [FromServices] IGetMembershipByIdQuery query)
        {
            var membership = query.Execute(id);
            return Ok(membership);
        }

        // POST api/<MembershipsController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] MembershipDto dto,[FromServices] ICreateMembershipCommand command)
        {
            command.Execute(dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<MembershipsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] MembershipDto dto,[FromServices] IUpdateMembershipCommand command)
        {
            dto.Id = id;
            command.Execute(dto);
            return NoContent();
        }

        // DELETE api/<MembershipsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id,[FromServices] IDeleteMembershipCommand command)
        {
            command.Execute(id);
            return NoContent();
        }
    }
}
