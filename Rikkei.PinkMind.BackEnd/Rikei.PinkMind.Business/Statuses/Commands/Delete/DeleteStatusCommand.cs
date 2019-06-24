using MediatR;

namespace Rikei.PinkMind.Business.Statuses.Commands.Delete
{
  public class DeleteStatusCommand : IRequest
  {
    public int ID { get; set; }
  }
}
