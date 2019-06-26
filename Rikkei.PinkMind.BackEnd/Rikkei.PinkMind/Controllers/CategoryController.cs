using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rikei.PinkMind.Business.Categories.Commands.Create;
using Rikei.PinkMind.Business.Categories.Commands.Delete;
using Rikei.PinkMind.Business.Categories.Commands.Update;
using Rikei.PinkMind.Business.Categories.Queries;
using Rikei.PinkMind.Business.Categories.Queries.GetAllCategory;

namespace Rikkei.PinkMind.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoryController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly ClaimsPrincipal _caller;

    public CategoryController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
      _mediator = mediator;
      _caller = httpContextAccessor.HttpContext.User;
    }

    // GET: api/Category/GetAll
    [Route("GetAll")]
    public async Task<ActionResult<CategoriesViewModel>> GetAllCategory()
    {
      return Ok(await _mediator.Send(new GetAllCategoryQuery()));
    }

    // GET: api/Category/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(int id)
    {
      var Category = await _mediator.Send(new GetCategoryQuery { ID = id });
      return new OkObjectResult(new
      {
        Message = "This is secure API and team details data!",
        Category.ID,
        Category.Name,
        Category.CreateAt,
        Category.CreateBy,
        Category.UpdateBy,
        Category.LastUpdate,
        Category.DelFlag
      });
    }

    // PUT: api/Category 
    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> PutCategory(UpdateCategoryCommand command)
    {
      await _mediator.Send(command);

      return NoContent();
    }

    // POST: api/Category
    [HttpPost]
    [Route("Create")]
    public async Task<Unit> PostCategory(CreateCategoryCommand command)
    {
      var category = await _mediator.Send(command);

      return category;
    }

    // DELETE: api/Category 
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategorys(int id)
    {
      await _mediator.Send(new DeleteCategoryCommand { ID = id });
      return NoContent();
    }
  }
}
