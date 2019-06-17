using MediatR;

namespace Rikei.PinkMind.Business.SpaceControls.Commands.DeletepmSpaceControls
{
  public class DeletepmSpaceControlCommand : IRequest
  {
    public int ID { get; set; }
  }
}
