using MediatR;

namespace Rikei.PinkMind.Business.IssueTypes.Queries
{
  public class GetIssueTypeQuery : IRequest<IssueTypeModel>
  {
    public long ID { get; set; }
  }
}
