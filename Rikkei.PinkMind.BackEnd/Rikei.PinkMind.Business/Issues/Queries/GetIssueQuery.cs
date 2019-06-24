using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Issues.Queries
{
  public class GetIssueQuery : IRequest<IssueModel>
  {
    public int ID { get; set; }
  }
}
