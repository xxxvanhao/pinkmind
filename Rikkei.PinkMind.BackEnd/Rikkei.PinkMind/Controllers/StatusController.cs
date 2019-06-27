using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rikei.PinkMind.Business.Statuses.Queries.GetAllStatus;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rikkei.PinkMind.API.Controllers
{
  [Route("api/[controller]")]
  [Produces("application/json")]
  [ApiController]
  public class StatusController : Controller
  {
    private readonly IMediator _mediator;
    private readonly ClaimsPrincipal _caller;

    public StatusController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
      _mediator = mediator;
      _caller = httpContextAccessor.HttpContext.User;
    }
    // GET: api/Status/GetAll
    [Route("GetAll")]
    public async Task<ActionResult<StatusViewModel>> GetAllStatus()
    {
      return Ok(await _mediator.Send(new GetAllStatusQuery( )));
    }

  }
}
