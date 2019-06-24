using MediatR;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Priorities.Commands.Create
{
  public class CreatePriorityCommand : IRequest<int>
  {

    public string Name { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public class Handler : IRequestHandler<CreatePriorityCommand, int>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<int> Handle(CreatePriorityCommand request, CancellationToken cancellationToken)
      {
        var entity = new Priority
        {
          Name = request.Name,
          CreateAt = DateTime.UtcNow,
          CreateBy = request.CreateBy,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true
        };
        _pmContext.Priorities.Add(entity);
        await _pmContext.SaveChangesAsync(cancellationToken);
        return entity.ID;
      }

    }
  }
}
