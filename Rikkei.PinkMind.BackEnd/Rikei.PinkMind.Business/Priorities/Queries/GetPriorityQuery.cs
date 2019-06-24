using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Priorities.Queries
{
  public class GetPriorityQuery : IRequest<PriorityModel>
  {
    public long ID { get; set; }
  }
}
