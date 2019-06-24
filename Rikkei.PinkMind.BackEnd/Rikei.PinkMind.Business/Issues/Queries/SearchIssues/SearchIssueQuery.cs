using MediatR;
using Rikei.PinkMind.Business.Issues.Queries.GetAllIssues;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Issues.Queries.SearchIssues
{
  public class SearchIssueQuery : IRequest<IssuesViewModel>
  {
    public string ProjectID { get; set; }
    public string Key { get; set; }
    public int StatusID { get; set; }
    public long AssigneeUser { get; set; }
    public int CategoryID { get; set; }
    public int MilestoneID { get; set; }
  }
}
