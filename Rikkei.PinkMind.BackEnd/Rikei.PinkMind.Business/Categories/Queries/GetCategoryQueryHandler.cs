using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Categories.Queries
{
  public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryModel>
  {
    private readonly PinkMindContext _pmContext;
    public GetCategoryQueryHandler(PinkMindContext pinkMindContext)
    {
      _pmContext = pinkMindContext;
    }
    public async Task<CategoryModel> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Categories.FindAsync(request.ID);

      if (entity == null)
      {
        throw new NotFoundException(nameof(Category), request.ID);
      }

      return CategoryModel.Create(entity);
    }
  }
}
