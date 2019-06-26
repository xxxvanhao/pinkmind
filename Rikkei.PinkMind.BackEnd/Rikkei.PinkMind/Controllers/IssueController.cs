using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rikei.PinkMind.Business.Issues.Commands.Create;
using Rikei.PinkMind.Business.Issues.Commands.Delete;
using Rikei.PinkMind.Business.Issues.Commands.Update;
using Rikei.PinkMind.Business.Issues.Queries;
using Rikei.PinkMind.Business.Issues.Queries.GetAllIssues;
using Rikei.PinkMind.Business.Issues.Queries.SearchIssues;
using Rikei.PinkMind.Business.Issues.Queries.GetIssueByUser;
using Microsoft.AspNetCore.Authorization;

namespace Rikkei.PinkMind.API.Controllers
{
  [Authorize(Policy = "ApiUser")]
  [Route("api/[controller]")]
  [ApiController]
  public class IssueController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly ClaimsPrincipal _caller;

    public IssueController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
      _mediator = mediator;
      _caller = httpContextAccessor.HttpContext.User;
    }

    // GET: api/Issue/GetAll/7
    [Route("GetAll/{id}")]
    public async Task<ActionResult<IssuesViewModel>> GetAllIssue(string id)
    {
      return Ok(await _mediator.Send(new GetAllIssuesQuery { ID = id }));
    }
    // GET: api/Issue/Search?
    [Route("Search/{projectID}")]
    public async Task<ActionResult<IssuesViewModel>> SearchIssue(string projectID, string key, long AssigneeUser, int CategoryID, int MilestoneID, int StatusID)
    {
      return Ok(await _mediator.Send(new SearchIssueQuery {ProjectID = projectID, Key = key, AssigneeUser = AssigneeUser, CategoryID = CategoryID, MilestoneID = MilestoneID, StatusID = StatusID }));
    }
    //GET api get by user : api/GetByUser/Key
    [Route("GetByUser")]
    public async Task<ActionResult<IssuesViewModel>> GetIssueByUser(string key)
    {
      var userID = _caller.Claims.Single(u => u.Type == "id");
      return Ok(await _mediator.Send(new GetIssueByUserQuery { Key = key, ID = Convert.ToInt64(userID) }));
    }
    // GET: api/Issue/GetDetail/7
    [HttpGet("GetDetail/{id}")]
    public async Task<IActionResult> GetIssue(int id)
    {
      var Issue = await _mediator.Send(new GetIssueQuery { ID = id });
      return new OkObjectResult(Issue);
    }

    // PUT: api/Issue 
    [HttpPut]
    public async Task<IActionResult> PutIssue([FromBody]UpdateIssueCommand command)
    {
      await _mediator.Send(command);

      return NoContent();
    }

    // POST: api/Issue
    [HttpPost]
    public async Task<IActionResult> PostIssue([FromBody]CreateIssueCommand command)
    {
      var userID = _caller.Claims.Single(u => u.Type == "id");
      await _mediator.Send(new CreateIssueCommand {
        IssueTypeID = command.IssueTypeID,
        Subject = command.Subject,
        Description = WebUtility.HtmlEncode(command.Description),
        StatusID = command.StatusID,
        AssigneeUser = command.AssigneeUser,
        PriorityID = command.PriorityID,
        CategoryID = command.CategoryID,
        MilestoneID = command.MilestoneID,
        VersionID = command.VersionID,
        ResolutionID = command.ResolutionID,
        DueDate = command.DueDate,
        ProjectID = command.ProjectID,
        CreateBy = Convert.ToInt64(userID.Value),
        UpdateBy = Convert.ToInt64(userID.Value)
      });

      return NoContent();
    }

    // DELETE: api/Issue 
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIssue(int id)
    {
      await _mediator.Send(new DeleteIssueCommand { ID = id });
      return NoContent();
    }
  }
}
