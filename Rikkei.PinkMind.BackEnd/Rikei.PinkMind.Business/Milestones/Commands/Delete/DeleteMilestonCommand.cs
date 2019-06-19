using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Milestones.Commands.Delete
{
    class DeleteVersioncommand : IRequest
    {
      public long ID { get; set; }
    }
}
