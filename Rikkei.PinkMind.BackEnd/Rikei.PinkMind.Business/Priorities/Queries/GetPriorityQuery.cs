using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Priorities.Queries
{
  public class GetAllPriorityQuery : IRequest<PriorityViewModel>
  {
    public int ID { get; set; }
  }
}
