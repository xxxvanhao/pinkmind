using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rikei.PinkMind.Business.IssueTypes.Queries.GetAllIssueType;
using Rikei.PinkMind.Business.Priorities.Queries.GetAllPriority;

namespace Rikkei.PinkMind.API.Controllers
{
  [Route("api/[controller]")]
  [Produces("application/json")]
  [ApiController]
  public class IssueTypeController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly ClaimsPrincipal _caller;

    public IssueTypeController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
      _mediator = mediator;
      _caller = httpContextAccessor.HttpContext.User;
    }

    // GET: api/IssueType/GetAll
    [Route("GetAll")]
    public async Task<ActionResult<IssueTypesViewModel>> GetAllIssueType()
    {
      return Ok(await _mediator.Send(new GetIAllssueTypeQuery { }));
    }
  }
}
