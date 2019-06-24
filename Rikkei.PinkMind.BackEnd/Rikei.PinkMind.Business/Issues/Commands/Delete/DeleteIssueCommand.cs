using MediatR;

namespace Rikei.PinkMind.Business.Issues.Commands.Delete
{
  public class DeleteIssueCommand : IRequest
  {
    public long ID { get; set; }
  }
}
