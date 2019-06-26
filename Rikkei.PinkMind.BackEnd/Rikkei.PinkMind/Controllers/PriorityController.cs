using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rikei.PinkMind.Business.Priorities.Commands.Create;
using Rikei.PinkMind.Business.Priorities.Commands.Delete;
using Rikei.PinkMind.Business.Priorities.Commands.Update;
using Rikei.PinkMind.Business.Priorities.Queries;
using Rikei.PinkMind.Business.Priorities.Queries.GetAllPriority;

namespace Rikkei.PinkMind.API.Controllers
{
  [Route("api/[controller]")]
  [Produces("application/json")]
  [ApiController]
  public class PriorityController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly ClaimsPrincipal _caller;

    public PriorityController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
      _mediator = mediator;
      _caller = httpContextAccessor.HttpContext.User;
    }

    // GET: api/Priority/GetAll
    [Route("GetAll")]
    public async Task<ActionResult<PriorityViewModel>> GetAllPriority()
    {
      return Ok(await _mediator.Send(new GetAllPriorityQuery {}));
    }
  }
}
