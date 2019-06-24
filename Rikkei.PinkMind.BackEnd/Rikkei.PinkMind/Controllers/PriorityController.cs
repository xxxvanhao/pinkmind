using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rikei.PinkMind.Business.Priorities.Commands.Create;
using Rikei.PinkMind.Business.Priorities.Commands.Delete;
using Rikei.PinkMind.Business.Priorities.Commands.Update;
using Rikei.PinkMind.Business.Priorities.Queries;

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

    // GET: api/Categories/GetAll
    [Route("GetAll")]
    public async Task<ActionResult<PriorityViewModel>> GetAllPriority(int id)
    {
      return Ok(await _mediator.Send(new GetAllPriorityQuery { ID = id }));
    }

    // GET: api/Priority/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPriority(int id)
    {
      var Priority = await _mediator.Send(new GetAllPriorityQuery { ID = id });
      return new OkObjectResult(new
      {
        Message = "Data for getting Priority: " + id,
        Priority.ID,
        Priority.Name,
        Priority.CreateAt,
        Priority.CreateBy,
        Priority.UpdateBy,
        Priority.LastUpdate,
        Priority.DelFlag
      });
    }

    // PUT: api/Priority 
    [HttpGet]
    [Route("Update")]
    public async Task<IActionResult> PutPriority(UpdatePriorityCommand command)
    {
      await _mediator.Send(command);

      return NoContent();
    }

    // POST: api/Priority
    [HttpPut]
    [Route("Create")]
    public async Task<int> PostPriority(CreatePriorityCommand command)
    {
      var Priority = await _mediator.Send(command);

      return Priority;
    }

    // DELETE: api/Priority 
    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> DeletePrioritys(int id)
    {
      await _mediator.Send(new DeletePriorityCommand { ID = id });
      return NoContent();
    }
  }
}
