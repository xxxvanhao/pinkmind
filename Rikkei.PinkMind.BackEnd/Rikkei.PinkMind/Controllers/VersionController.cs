using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rikei.PinkMind.Business.Versions.Queries.GetVersion;
using Rikei.PinkMind.Business.Versions.Commands.Update;
using Rikei.PinkMind.Business.Versions.Commands.Create;
using Rikei.PinkMind.Business.Versions.Commands.Delete;
namespace Rikkei.PinkMind.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VersionController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly ClaimsPrincipal _caller;

    public VersionController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
      _mediator = mediator;
      _caller = httpContextAccessor.HttpContext.User;
    }

    // GET: api/Version/getall/1
    //[Route("getall/{id}")]
    //public async Task<ActionResult<VersionsViewModel>> GetAllVersion(int id)
    //{
    //  return Ok(await _mediator.Send(new GetAllVersionsQueryHandler()));
    //}

    // GET: api/Version/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetVersion(int id)
    {
      var Version = await _mediator.Send(new GetVersionQuery { ID = id });
      return new OkObjectResult(Version);
    }

    // PUT: api/Version 
    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> PutVersion(UpdateVersionCommand command)
    {
      await _mediator.Send(command);

      return NoContent();
    }

    // POST: api/Version
    [HttpPost]
    [Route("Create")]
    public async Task<Unit> PostVersion(CreateVersionCommand command)
    {
      var Version = await _mediator.Send(command);

      return Version;
    }

    // DELETE: api/Version 
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVersions(int id)
    {
      await _mediator.Send(new DeleteVersioncommand { ID = id });
      return NoContent();
    }
  }
}
