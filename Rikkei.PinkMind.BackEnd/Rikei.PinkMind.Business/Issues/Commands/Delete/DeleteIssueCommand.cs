using MediatR;

namespace Rikei.PinkMind.Business.Issues.Commands.Delete
{
  class DeleteIssueCommand : IRequest
  {
    public long ID { get; set; }
  }
}
