using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Categories.Queries.GetAllCategory
{
  public class GetAllCategoryQuery : IRequest<CategoriesViewModel>
  {
    public int ID { get; set; }
  }
}
