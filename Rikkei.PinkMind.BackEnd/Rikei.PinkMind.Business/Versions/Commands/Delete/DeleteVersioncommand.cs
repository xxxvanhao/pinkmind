using MediatR;

namespace Rikei.PinkMind.Business.Versions.Commands.Delete
{
  class DeleteVersioncommand : IRequest
    {
      public long ID { get; set; }
    }
}
