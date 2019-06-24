using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rikei.PinkMind.Business.ReUpdate.Create;
using Rikei.PinkMind.Business.ReUpdate.GetDetails;

namespace Rikkei.PinkMind.API.Controllers
{
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
    [HttpGet]
    public async Task<ActionResult<ReUpdateViewModel>> GetReUpdate()
    {
      //var userID = _caller.Claims.Single(u => u.Type == "id"); /*Convert.ToInt64(userID.Value)*/
      return Ok(await _mediator.Send(new GetReUpdateQuery { userID = 2243545045909014 }));
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
