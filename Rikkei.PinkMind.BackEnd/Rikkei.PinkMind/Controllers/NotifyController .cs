using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rikei.PinkMind.Business.Notifies.Commands.Create;
using Rikei.PinkMind.Business.Notifies.Commands.Delete;
using Rikei.PinkMind.Business.Notifies.Queries;
using Rikei.PinkMind.Business.Notifies.Queries.GetAll;

namespace Rikkei.PinkMind.API.Controllers
{
  [Route("api/[controller]")]
  [Produces("application/json")]
  [ApiController]
  public class NotifyController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly ClaimsPrincipal _caller;

    public NotifyController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
      _mediator = mediator;
      _caller = httpContextAccessor.HttpContext.User;
    }

    //// GET: api/Notify/GetAll
    [HttpGet]
    public async Task<ActionResult<NotifyViewModel>> GetAllNotify()
    {
      var userID = _caller.Claims.Single(u => u.Type == "id");
      return Ok(await _mediator.Send(new GetAllNotifyQuery { userID = Convert.ToInt64(userID.Value) }));
    }
  }
}
