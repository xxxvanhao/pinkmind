using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rikei.PinkMind.Business.TeamDetails.Commands.Create;
using Rikei.PinkMind.Business.TeamDetails.Commands.Delete;
using Rikei.PinkMind.Business.TeamDetails.Commands.Update;
using Rikei.PinkMind.Business.TeamDetails.Queries.GetAllTeamDetail;
using Rikei.PinkMind.Business.TeamDetails.Queries.GetTeamDetail;

namespace Rikkei.PinkMind.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TeamDetailsController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly ClaimsPrincipal _caller;

    public TeamDetailsController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
      _mediator = mediator;
      _caller = httpContextAccessor.HttpContext.User;
    }

    // GET: api/TeamDetails/getall/5
    [Route("getall/{id}")]
    public async Task<ActionResult<TeamDetailsViewModel>> GetAllTeamDetails(int id)
    {
      return Ok(await _mediator.Send(new GetAllTeamDetailsQuery { ID = id }));
    }

    // GET: api/TeamDetails/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeamDetails(int id)
    {
      var teamdDetails = await _mediator.Send(new GetTeamDetailQuery{ ID = id });
      return new OkObjectResult(new
      {
        Message = "This is secure API and team details data!",
        teamdDetails.ID,
        teamdDetails.TeamID,
        teamdDetails.UserID,
        teamdDetails.RoleID,
        teamdDetails.JoinedOn,
        teamdDetails.AddBy,
        teamdDetails.DelFlag
      });
    }

    // PUT: api/TeamDetails 
    [HttpPut]
    public async Task<IActionResult> PutTeamDetails([FromBody]UpdateTeamDetailCommand command)
    {
      await _mediator.Send(command);

      return NoContent();
    }

    // POST: api/TeamDetails
    [HttpPost]
    public async Task<int> PostTeamDetails([FromBody]CreateTeamDetailCommand command)
    {
      var teamDetailsId = await _mediator.Send(command);

      return teamDetailsId;
    }

    // DELETE: api/TeamDetails 
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeamDetails(int id)
    {
      await _mediator.Send(new DeleteTeamDetailCommand { ID = id });
      return NoContent();
    }
  }
}
