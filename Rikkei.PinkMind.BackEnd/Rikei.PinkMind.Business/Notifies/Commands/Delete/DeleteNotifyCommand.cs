using MediatR;

namespace Rikei.PinkMind.Business.Notifies.Commands.Delete
{
  public class DeleteNotifyCommand : IRequest
  {
    public long ID { get; set; }
  }
}
