using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Issues.Commands.Delete
{
  class DeleteIssueCommand : IRequest
  {
    public long ID { get; set; }
  }
}
