using MediatR;

namespace Rikei.PinkMind.Business.Versions.Commands.Delete
{
  public class DeleteVersioncommand : IRequest
  {
    public long ID { get; set; }
  }
}
