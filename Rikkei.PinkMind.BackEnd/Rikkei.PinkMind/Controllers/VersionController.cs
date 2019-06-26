using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rikei.PinkMind.Business.Versions.Queries.GetAllVersions;

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

    //GET: api/Version/GetAll
    [Route("GetAll")]
    public async Task<ActionResult<VersionViewModel>> GetAllVersion()
    {
      return Ok(await _mediator.Send(new GetAllVersionQuery { }));
    }
  }
}
