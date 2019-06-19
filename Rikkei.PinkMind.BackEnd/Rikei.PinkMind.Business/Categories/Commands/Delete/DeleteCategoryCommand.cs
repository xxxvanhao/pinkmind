using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Categories.Commands.Delete
{
  public class DeleteCategoryCommand : IRequest
  {
    public long ID { get; set; }
  }
}
