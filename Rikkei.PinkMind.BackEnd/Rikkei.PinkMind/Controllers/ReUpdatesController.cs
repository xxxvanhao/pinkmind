using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rikei.PinkMind.Business.ReUpdate.Create;
using Rikei.PinkMind.Business.ReUpdate.GetDetails;

namespace Rikkei.PinkMind.API.Controllers
{

    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReUpdatesController : ControllerBase
    {
    private readonly IMediator _mediator;
    private readonly ClaimsPrincipal _caller;

    public ReUpdatesController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
      _mediator = mediator;
      _caller = httpContextAccessor.HttpContext.User;
    }

    // GET: api/ReUpdates
    [HttpGet("{pKey}")]
    public async Task<ActionResult<ReUpdateViewModel>> GetReUpdate(string pKey)
    {
      var userID = _caller.Claims.Single(u => u.Type == "id");
      return Ok(await _mediator.Send(new GetReUpdateQuery { projectKey = pKey, userID = Convert.ToInt64(userID.Value) }));
    }

    [HttpPost]
    public async Task<IActionResult> PostReUpdate([FromBody]CreateReUpdateCommand command)
    {
      //var userID = _caller.Claims.Single(u => u.Type == "id");
      await _mediator.Send(command);

      return NoContent();
    }
  }
}
