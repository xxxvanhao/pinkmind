using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rikei.PinkMind.Business.Resolutions.Commands.Create;
using Rikei.PinkMind.Business.Resolutions.Commands.Delete;
using Rikei.PinkMind.Business.Resolutions.Commands.Update;
using Rikei.PinkMind.Business.Resolutions.Queries;

namespace Rikkei.PinkMind.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ResolutionController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly ClaimsPrincipal _caller;

    public ResolutionController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
      _mediator = mediator;
      _caller = httpContextAccessor.HttpContext.User;
    }

    // GET: api/Resolution/getall/1
    //[Route("getall/{id}")]
    //public async Task<ActionResult<ResolutionViewModel>> GetAllResolution(int id)
    //{
    //  return Ok(await _mediator.Send(new GetAllResolutionQuery { ID = id }));
    //}

    // GET: api/Resolution/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetResolution(int id)
    {
      var Resolution = await _mediator.Send(new GetResolutionQuery { ID = id });
      return new OkObjectResult(new
      {
        Message = "This is secure API and team details data!",
        Resolution.ID,
        Resolution.Name,
        Resolution.CreateAt,
        Resolution.CreateBy,
        Resolution.UpdateBy,
        Resolution.LastUpdate,
        Resolution.DelFlag
      });
    }

    // PUT: api/Resolution 
    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> PutResolution(UpdateResolutionCommand command)
    {
      await _mediator.Send(command);

      return NoContent();
    }

    // POST: api/Resolution
    [HttpPost]
    [Route("Create")]
    public async Task<Unit> PostResolution(CreateResolutionCommand command)
    {
      var Resolution = await _mediator.Send(command);

      return Resolution;
    }

    // DELETE: api/Resolution 
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteResolutions(int id)
    {
      await _mediator.Send(new DeleteResolutionCommand { ID = id });
      return NoContent();
    }
  }
}
