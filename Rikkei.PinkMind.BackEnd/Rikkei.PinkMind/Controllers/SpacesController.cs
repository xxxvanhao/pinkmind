using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rikei.PinkMind.Business.pmSpaces.Commands.CreatepmSpace;
using Rikei.PinkMind.Business.pmSpaces.Commands.DeletepmSpace;
using Rikei.PinkMind.Business.pmSpaces.Commands.UpdatePmSpace;
using Rikei.PinkMind.Business.pmSpaces.Queries.GetpmSpace;

namespace Rikkei.PinkMind.API.Controllers
{
  [Authorize(Policy = "ApiUser")]
  [Route("api/[controller]")]
  [ApiController]
  public class SpacesController : ControllerBase
    {
    private readonly IMediator _mediator;
    private readonly ClaimsPrincipal _caller;

    public SpacesController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
      _mediator = mediator;
      _caller = httpContextAccessor.HttpContext.User;
    }

    // GET: api/Spaces/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSpace(string id)
    {
      var spaceInfo = await _mediator.Send(new GetpmSpaceQuery { SpaceID = id });
      return new OkObjectResult(new
      {
        Message = "This is secure API and space data!",
        spaceInfo.SpaceID,
        spaceInfo.OrganizationName,
        spaceInfo.CreateBy,
        spaceInfo.CreateAt,
        spaceInfo.UpdateBy,
        spaceInfo.LastUpdate,
        spaceInfo.DelFlag,
        spaceInfo.CheckUpdate
      });
    }

    // PUT: api/Spaces 
    [HttpPut]
    public async Task<IActionResult> PutSpace([FromBody]UpdatepmSpaceCommand command)
    {                               
      await _mediator.Send(command);
      
      return NoContent();
    }

    // POST: api/Spaces
    [HttpPost]
    public async Task<IActionResult> PostSpace([FromBody]CreatepmSpaceCommand command)
    {
      var userID = _caller.Claims.Single(u => u.Type == "id");
      await _mediator.Send(new CreatepmSpaceCommand
      {
        SpaceID = command.SpaceID,
        OrganizationName = command.OrganizationName, 
        CreateBy = Convert.ToInt64(userID.Value),
        UpdateBy = Convert.ToInt64(userID.Value)
      });
      
      return NoContent();
    }

    // DELETE: api/Spaces 
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSpace(string id)
    {
      await _mediator.Send(new DeletepmSpaceCommand { SpaceID = id });
      return NoContent();
    }
  }
}
