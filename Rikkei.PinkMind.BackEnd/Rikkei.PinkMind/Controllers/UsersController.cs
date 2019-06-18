using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rikei.PinkMind.Business.Users.Commands.CreateUser;
using Rikei.PinkMind.Business.Users.Commands.DeleteUser;
using Rikei.PinkMind.Business.Users.Commands.UpdateUser;
using Rikei.PinkMind.Business.Users.Queries.GetUserDetail;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;

namespace Rikkei.PinkMind.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly ClaimsPrincipal _caller;

    public UsersController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
      _mediator = mediator;
      _caller = httpContextAccessor.HttpContext.User;
    }

    // GET: api/Users
    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<User>>> GetUser()
    //{
    //}

    // GET: api/Users/5
    [Authorize(Policy = "ApiUser")]
    public async Task<IActionResult> GetUser()
    {
      var userID = _caller.Claims.Single(u => u.Type == "id");
      var userInfo = await _mediator.Send(new GetUserDetailQuery { ID = Convert.ToInt32(userID.Value)});
      return new OkObjectResult(new
      {
        Message = "This is secure API and user data!",
        userInfo.ID,
        userInfo.Email,
        userInfo.FirstName,
        userInfo.LastName,
        userInfo.PictureUrl,
        userInfo.SpaceID,
        userInfo.CreateAt,
        userInfo.LastUpdate
      });
    }

    // PUT: api/Users
    [Authorize(Policy = "ApiUser")]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser([FromBody]UpdateUserCommand command)
    {
      await _mediator.Send(command);

      return NoContent();
    }

    // POST: api/Users
    [HttpPost]
    public async Task<IActionResult> PostUser([FromBody]CreateUserCommand command)
    {
      await _mediator.Send(command);

      return NoContent();
    }

    // DELETE: api/Users
    [Authorize(Policy = "ApiUser")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
      await _mediator.Send(new DeleteUserCommand { ID = id });
      return NoContent();
    }
  }
}
