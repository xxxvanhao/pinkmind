using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rikei.PinkMind.Business.Users.Queries.GetUserDetail;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;

namespace Rikkei.PinkMind.API.Controllers
{
    //[Authorize(Policy = "ApiUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Users
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<User>>> GetUser()
        //{
        //}

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetailModel>> GetUser(int id)
        {
          return Ok(await _mediator.Send(new GetUserDetailQuery { ID = id }));
        }

        //// PUT: api/Users/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser(int id, User user)
        //{
        //    if (id != user.ID)
        //    {
        //        return BadRequest();
        //    }

        //    return NoContent();
        //}

        //// POST: api/Users
        //[HttpPost]
        //public async Task<ActionResult<User>> PostUser(User user)
        //{
           
        //}

        //// DELETE: api/Users/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<User>> DeleteUser(int id)
        //{
          
        //}
    }
}
