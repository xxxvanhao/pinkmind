using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rikei.PinkMind.Business.SpaceControls.Commands.CreatepmSpaceControl;
using Rikei.PinkMind.Business.SpaceControls.Commands.DeletepmSpaceControls;
using Rikei.PinkMind.Business.SpaceControls.Queries.GetpmSpaceControl;

namespace Rikkei.PinkMind.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize(Policy = "ApiUser")]
  public class SpaceControlsController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly ClaimsPrincipal _caller;

    public SpaceControlsController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
      _mediator = mediator;
      _caller = httpContextAccessor.HttpContext.User;
    }

    // GET: api/SpaceControls
    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<User>>> GetSpaceControl()
    //{
    //}

    // GET: api/SpaceControls/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSpaceControl(long id)
    {
      var spaceControlInfo = await _mediator.Send(new GetpmSpaceControlQuery { userId = id });
      return new OkObjectResult(new
      {
        Message = "This is secure API and space control data!",
        spaceControlInfo.SpaceID,
        spaceControlInfo.ControlBy,
      });
    }

    // POST: api/SpaceControls
    [HttpPost]
    public async Task<IActionResult> PostSpaceControl([FromBody]CreatepmSpaceControlCommand command)
    {
      await _mediator.Send(command);

      return NoContent();
    }

    // DELETE: api/Users
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSpaceControl(int id)
    {
      await _mediator.Send(new DeletepmSpaceControlCommand { ID = id });
      return NoContent();
    }
  }
}
