using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Categories.Queries.GetAllCategory
{
  public class CategoriesViewModel : IRequest
  {
    public IEnumerable<CategoriesDTO> Categories { get; set; }
  }
}
