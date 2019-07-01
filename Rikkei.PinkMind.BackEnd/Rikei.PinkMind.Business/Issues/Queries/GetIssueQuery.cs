using MediatR;
using Rikei.PinkMind.Business.Issues.Queries.GetAllIssues;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Issues.Queries
{
  public class GetIssueQuery : IRequest<IssuesDTO>
  {
    public int ID { get; set; }
  }
}
