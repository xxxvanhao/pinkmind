using MediatR;
using Rikei.PinkMind.Business.Issues.Queries.GetAllIssues;

namespace Rikei.PinkMind.Business.Issues.Queries.GetIssueByUser
{
  public class GetIssueByUserQuery : IRequest<IssuesViewModel>
  {
    public string Key { get; set; }
    public long ID { get; set; }
  }
}
