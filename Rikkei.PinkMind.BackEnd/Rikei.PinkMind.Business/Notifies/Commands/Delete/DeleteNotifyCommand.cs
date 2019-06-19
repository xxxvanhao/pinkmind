using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Notifies.Commands.Delete
{
    class DeleteNotifyCommand : IRequest
  {
    public long ID { get; set; }
  }
}
