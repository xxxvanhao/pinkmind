using MediatR;

namespace Rikei.PinkMind.Business.Milestones.Commands.Delete
{
  class DeleteVersioncommand : IRequest
    {
      public long ID { get; set; }
    }
}
