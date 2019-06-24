using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Issues.Queries.GetAllIssues
{
  public class GetAllIssuesQuery : IRequest<IssuesViewModel>
  {
    public string ID { get; set; }
  }
}
