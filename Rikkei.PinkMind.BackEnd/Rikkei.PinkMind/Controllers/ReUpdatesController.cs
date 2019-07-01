using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Rikei.PinkMind.Business.HubConfig;
using Rikei.PinkMind.Business.ReUpdate.Create;
using Rikei.PinkMind.Business.ReUpdate.GetDetails;
using Rikei.PinkMind.Business.TimerFeatures;

namespace Rikkei.PinkMind.API.Controllers
{

    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReUpdatesController : ControllerBase
    {
    private readonly IMediator _mediator;
    private readonly ClaimsPrincipal _caller;
    private IHubContext<RecentUpdateHub> _hub;

    public ReUpdatesController(IMediator mediator, IHttpContextAccessor httpContextAccessor, IHubContext<RecentUpdateHub> hub)
    {
      _mediator = mediator;
      _caller = httpContextAccessor.HttpContext.User;
      _hub = hub;
    }

    // GET: api/ReUpdates
    [Route("signalr/{pKey}")]
    public IActionResult GetAllReUpdate(string pKey)
    {
      var userID = _caller.Claims.Single(u => u.Type == "id");
      /*var timerManager = new TimerManager(() => */_hub.Clients.All.SendAsync("transferreupdata", "hihi");

      return Ok(new { Message = "Request Completed" });
    }

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
