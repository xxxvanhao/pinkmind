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
    [Route("GetAll")]
    public async Task<ActionResult<NotifyViewModel>> GetAllNotify()
    {
      return Ok(await _mediator.Send(new GetAllNotifyQuery()));
    }
  }
}
