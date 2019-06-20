using MediatR;

namespace Rikei.PinkMind.Business.Notifies.Commands.Delete
{
  class DeleteNotifyCommand : IRequest
  {
    public long ID { get; set; }
  }
}
