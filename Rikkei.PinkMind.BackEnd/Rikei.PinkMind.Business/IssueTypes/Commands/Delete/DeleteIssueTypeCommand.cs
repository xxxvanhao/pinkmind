using MediatR;

namespace Rikei.PinkMind.Business.IssueTypes.Commands.Delete
{
  public class DeleteIssueTypeCommand : IRequest
  {
    public long ID { get; set; }
  }
}
