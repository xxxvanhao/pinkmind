using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rikei.PinkMind.Business.Milestones.Queries.GetAllMileston;
using Rikei.PinkMind.Business.Milestones.Queries.GetMileston;
using Rikei.PinkMind.Business.Milestones.Commands.Update;
using Rikei.PinkMind.Business.Milestones.Commands.Create;
using Rikei.PinkMind.Business.Milestones.Commands.Delete;
namespace Rikkei.PinkMind.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MilestonController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly ClaimsPrincipal _caller;

    public MilestonController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
      _mediator = mediator;
      _caller = httpContextAccessor.HttpContext.User;
    }

    //GET: api/Mileston/getall
    [Route("getall")]
    public async Task<ActionResult<MilestonsViewModel>> GetAllMileston()
    {
      return Ok(await _mediator.Send(new GetAllMilestoneQuery()));
    }

  }
}
