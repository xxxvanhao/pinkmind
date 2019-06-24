using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Categories.Queries.GetAllCategory
{
  public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoryQuery, CategoriesViewModel>
  {

    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;
    public GetAllCategoriesQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }

    public async Task<CategoriesViewModel> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
      var Categories = from ct in _pmContext.Categories select ct;
      var AllCategories = await Categories.ToListAsync(cancellationToken);

      var model = new CategoriesViewModel
      {
        Categories = _mapper.Map<IEnumerable<CategoriesDTO>>(AllCategories)
      };

      return model;
    }
  }
}
