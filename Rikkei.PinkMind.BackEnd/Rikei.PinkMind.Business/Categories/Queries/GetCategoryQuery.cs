using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Categories.Queries
{
  public class GetCategoryQuery : IRequest<CategoryModel>
  {
    public long ID { get; set; }
  }
}
