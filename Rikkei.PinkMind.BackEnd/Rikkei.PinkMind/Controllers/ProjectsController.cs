using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rikei.PinkMind.Business.Projects.Commands.Create;
using Rikei.PinkMind.Business.Projects.Commands.Delete;
using Rikei.PinkMind.Business.Projects.Commands.Update;
using Rikei.PinkMind.Business.Projects.Queries;
using Rikei.PinkMind.Business.Projects.Queries.GetProjects;

namespace Rikkei.PinkMind.API.Controllers
{
  [Authorize(Policy = "ApiUser")]
  [Route("api/[controller]")]
  [ApiController]
  public class ProjectsController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly ClaimsPrincipal _caller;

    public ProjectsController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
      _mediator = mediator;
      _caller = httpContextAccessor.HttpContext.User;
    }

    // GET: api/Projects
    [HttpGet]
    public async Task<ActionResult<ProjectViewModel>> GetProject()
    {
      var userID = _caller.Claims.Single(u => u.Type == "id");
      return Ok(await _mediator.Send(new GetProjectQuery { userID = Convert.ToInt64(userID.Value) }));
    }

    // PUT: api/Projects 
    [HttpPut]
    public async Task<IActionResult> PutProject([FromBody]UpdateProjectCommand command)
    {
      await _mediator.Send(command);

      return NoContent();
    }

    // POST: api/Projects
    [HttpPost]
    public async Task<IActionResult> PostProject([FromBody]CreateProjectCommand command)
    {
      var userID = _caller.Claims.Single(u => u.Type == "id");
      await _mediator.Send(new CreateProjectCommand
      {
        ID = command.ID,
        Name = command.Name,
        CreateBy = Convert.ToInt64(userID.Value),
        UpdateBy = Convert.ToInt64(userID.Value)
      });

      return NoContent();
    }

    // DELETE: api/Projects/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
      await _mediator.Send(new DeleteProjectCommand { ID = id });
      return NoContent();
    }
  }
}
