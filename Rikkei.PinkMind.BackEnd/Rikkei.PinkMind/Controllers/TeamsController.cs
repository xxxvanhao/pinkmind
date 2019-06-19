using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rikei.PinkMind.Business.Teams.Commands.Create;
using Rikei.PinkMind.Business.Teams.Commands.Delete;
using Rikei.PinkMind.Business.Teams.Commands.Update;
using Rikei.PinkMind.Business.Teams.Queries.GetTeams;

namespace Rikkei.PinkMind.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TeamsController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly ClaimsPrincipal _caller;

    public TeamsController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
      _mediator = mediator;
      _caller = httpContextAccessor.HttpContext.User;
    }

    // GET: api/Teams/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeam(int id)
    {
      var teamInfo = await _mediator.Send(new GetTeamControlQuery { ID = id });
      return new OkObjectResult(new
      {
        Message = "This is secure API and team data!",
        teamInfo.ID,
        teamInfo.Name,
        teamInfo.CreateBy,
        teamInfo.CreateAt,
        teamInfo.UpdateBy,
        teamInfo.LastUpdate,
        teamInfo.DelFlag,
        teamInfo.CheckUpdate
      });
    }

    // PUT: api/Teams 
    [HttpPut]
    public async Task<IActionResult> PutTeam([FromBody]UpdateTeamCommand command)
    {
      await _mediator.Send(command);

      return NoContent();
    }

    // POST: api/Teams
    [HttpPost]
    public async Task<int> PostTeam([FromBody]CreateTeamCommands command)
    {
      var teamId = await _mediator.Send(command);

      return teamId;
    }

    // DELETE: api/Teams 
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeam(int id)
    {
      await _mediator.Send(new DeleteTeamCommand { ID = id });
      return NoContent();
    }
  }
}
