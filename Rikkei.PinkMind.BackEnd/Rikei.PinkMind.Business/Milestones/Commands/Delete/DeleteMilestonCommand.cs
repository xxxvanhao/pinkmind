using MediatR;

namespace Rikei.PinkMind.Business.Milestones.Commands.Delete
{
  public class DeleteMilestoncommand : IRequest
  {
    public long ID { get; set; }
  }
}
