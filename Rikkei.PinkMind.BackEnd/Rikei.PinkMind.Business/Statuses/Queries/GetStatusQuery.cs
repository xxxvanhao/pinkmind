using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Statuses.Queries
{
  public class GetStatusQuery : IRequest<StatusModel>
  {
    public int ID { get; set; }
  }
}
