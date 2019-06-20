using System;
using System.Collections.Generic;

namespace Rikei.PinkMind.Business.Issues.Queries.GetAllIssues
{
  public class IssuesViewModel
  {
    public IEnumerable<IssuesDTO> Issues { get; set; }
  }
}
