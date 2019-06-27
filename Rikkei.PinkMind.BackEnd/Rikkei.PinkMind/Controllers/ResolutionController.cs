using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rikei.PinkMind.Business.Resolutions.Commands.Create;
using Rikei.PinkMind.Business.Resolutions.Commands.Delete;
using Rikei.PinkMind.Business.Resolutions.Commands.Update;
using Rikei.PinkMind.Business.Resolutions.Queries;
using Rikei.PinkMind.Business.Resolutions.Queries.GetAllResolution;

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

    //GET: api/Resolution/GetAll
    [Route("GetAll")]
    public async Task<ActionResult<ResolutionViewModel>> GetAllResolution()
    {
      return Ok(await _mediator.Send(new GetAllResolutionQuery { }));
    }
  }
}
