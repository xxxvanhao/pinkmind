using MediatR;

namespace Rikei.PinkMind.Business.Priorities.Commands.Delete
{
  class DeletePriorityCommand : IRequest
  {
    public long ID { get; set; }
  }
}
