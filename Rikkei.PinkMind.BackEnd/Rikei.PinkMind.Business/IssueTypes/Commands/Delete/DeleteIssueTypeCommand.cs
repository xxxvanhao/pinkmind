using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.IssueTypes.Commands.Delete
{
  public class DeleteIssueTypeCommand : IRequest
  {
    public long ID { get; set; }
  }
}
