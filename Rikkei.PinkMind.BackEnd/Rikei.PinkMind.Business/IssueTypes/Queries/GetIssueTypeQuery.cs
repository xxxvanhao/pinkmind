using MediatR;

namespace Rikei.PinkMind.Business.IssueTypes.Queries
{
  class GetIssueTypeQuery : IRequest<IssueTypeModel>
  {
    public long ID { get; set; }
  }
}
