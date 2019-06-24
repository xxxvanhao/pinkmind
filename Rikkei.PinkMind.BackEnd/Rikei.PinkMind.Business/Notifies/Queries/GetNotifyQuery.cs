using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Notifies.Queries
{
  public class GetNotifyQuery : IRequest<NotifyModel>
  {
    public long ID { get; set; }
  }
}
