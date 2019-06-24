using MediatR;

namespace Rikei.PinkMind.Business.Priorities.Commands.Delete
{
  public class DeletePriorityCommand : IRequest
  {
    public int ID { get; set; }
  }
}
