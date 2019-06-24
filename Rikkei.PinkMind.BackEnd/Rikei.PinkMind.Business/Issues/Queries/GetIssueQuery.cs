using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Issues.Queries
{
    class GetIssueQuery : IRequest<IssueModel>
  {
    public long ID { get; set; }
  }
}
