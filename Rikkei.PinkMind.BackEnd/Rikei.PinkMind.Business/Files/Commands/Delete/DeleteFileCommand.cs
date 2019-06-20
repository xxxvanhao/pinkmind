using MediatR;

namespace Rikei.PinkMind.Business.Files.Commands.Delete
{
  public class DeleteFileCommand : IRequest
  {
    public long ID { get; set; }
  }
}
