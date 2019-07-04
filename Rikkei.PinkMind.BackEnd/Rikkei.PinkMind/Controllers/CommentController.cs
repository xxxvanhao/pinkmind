using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rikei.PinkMind.Business.Comments.Commands.Create;
using Rikei.PinkMind.Business.Comments.Commands.Delete;
using Rikei.PinkMind.Business.Comments.Commands.Update;
using Rikei.PinkMind.Business.Comments.Comments.GetAllComment;
using Rikei.PinkMind.Business.Comments.Queries;
using Rikei.PinkMind.Business.Comments.Queries.GetAllComment;

namespace Rikkei.PinkMind.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CommentController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly ClaimsPrincipal _caller;

    public CommentController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
      _mediator = mediator;
      _caller = httpContextAccessor.HttpContext.User;
    }

    // GET: api/Comment/GetAll/7
    [Route("GetAll/{id}")]
    public async Task<ActionResult<CommentsViewModel>> GetAllComment(int id)
    {
      return Ok(await _mediator.Send(new GetAllCommentsQuery { ID = id }));
    }

    // GET: api/Comment/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetComment(int id)
    {
      var comment = await _mediator.Send(new GetCommentQuery { ID = id });
      return new OkObjectResult(new
      {
        Message = "Comment API!",
        comment.ID,
        comment.IssueID,
        comment.LastUpdate,
        comment.UpdateBy,
        comment.CheckUpdate,
        comment.Content,
        comment.CreateAt,
        comment.CreateBy
      });
    }

    // PUT: api/Comment
    [Authorize(Policy = "ApiUser")]
    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> PutComment([FromBody]UpdateCommentCommand command)
    {
      var userID = _caller.Claims.Single(u => u.Type == "id");
      command.UpdateBy = Convert.ToInt64(userID.Value);
      await _mediator.Send(command);
      return NoContent();
    }

    // POST: api/Comment
    [HttpPost]
    [Authorize(Policy = "ApiUser")]
    [Route("Create")]
    public async Task<Unit> PostComment([FromBody]CreateCommentCommand command)
    {
      var userID = _caller.Claims.Single(u => u.Type == "id");
      command.CreateBy = Convert.ToInt64(userID.Value);
      command.UpdateBy = Convert.ToInt64(userID.Value);
      var Comment = await _mediator.Send(command);
      try
      {
        var file = Request.Form.Files[0];
        var folderName = Path.Combine("issue", "comment");
        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

        if (file.Length > 0)
        {
          var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
          var fullPath = Path.Combine(pathToSave, fileName);
          var dbPath = Path.Combine(folderName, fileName);

          using (var stream = new FileStream(fullPath, FileMode.Create))
          {
            file.CopyTo(stream);
          }
        }
        else
        {
          return Unit.Value;
        }
      }
      catch (Exception ex)
      {
        return Unit.Value;
      }
      return Unit.Value;
    }

    // DELETE: api/Comment 
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(int id)
    {
      await _mediator.Send(new DeleteCommentCommand { ID = id });
      return NoContent();
    }
  }
}
