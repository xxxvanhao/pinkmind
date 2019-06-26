using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rikei.PinkMind.Business.Notifies.Commands.Create;
using Rikei.PinkMind.Business.Notifies.Commands.Delete;
using Rikei.PinkMind.Business.Notifies.Queries;

namespace Rikkei.PinkMind.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NotifyController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly ClaimsPrincipal _caller;

    public NotifyController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
      _mediator = mediator;
      _caller = httpContextAccessor.HttpContext.User;
    }

    //// GET: api/Notifies/getall/1
    //[Route("getall/{id}")]
    //public async Task<ActionResult<NotifyViewModel>> GetAllNotify(int id)
    //{
    //  return Ok(await _mediator.Send(new GetAllNotifyQuery { ID = id }));
    //}

    // GET: api/Notify/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetNotify(int id)
    {
      var Notify = await _mediator.Send(new GetNotifyQuery { ID = id });
      return new OkObjectResult(new
      {
        Message = "This is secure API and team details data!",
        Notify.ID,
        Notify.Status,
        Notify.IssueID,
        Notify.UserID
      });
    }

    // POST: api/Notify
    [HttpPost]
    [Route("Create")]
    public async Task<Unit> PostNotify(CreateNotifyCommand command)
    {
      var Notify = await _mediator.Send(command);

      return Notify;
    }

    // DELETE: api/Notify 
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNotifys(int id)
    {
      await _mediator.Send(new DeleteNotifyCommand { ID = id });
      return NoContent();
    }
  }
}
