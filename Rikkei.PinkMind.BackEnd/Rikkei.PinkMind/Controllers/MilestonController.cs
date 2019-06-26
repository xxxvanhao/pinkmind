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

    // GET: api/Mileston/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMileston(int id)
    {
      var Mileston = await _mediator.Send(new GetMilestoneQuery { ID = id });
      return new OkObjectResult(Mileston);
    }

    // PUT: api/Mileston 
    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> PutMileston(UpdateMilestonCommand command)
    {
      await _mediator.Send(command);

      return NoContent();
    }

    // POST: api/Mileston
    [HttpPost]
    [Route("Create")]
    public async Task<Unit> PostMileston(CreateMilestonCommand command)
    {
      var Mileston = await _mediator.Send(command);

      return Mileston;
    }

    // DELETE: api/Mileston 
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMilestons(int id)
    {
      await _mediator.Send(new DeleteMilestoncommand { ID = id });
      return NoContent();
    }
  }
}
