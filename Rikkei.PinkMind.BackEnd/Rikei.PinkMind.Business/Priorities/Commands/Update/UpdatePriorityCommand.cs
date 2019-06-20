using MediatR;
using Microsoft.EntityFrameworkCore;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Priorities.Commands.Update
{
  class UpdatePriorityCommand : IRequest
  {
    public long ID { get; set; }
    public string Name { get; set; }
    public int UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public byte[] CheckUpdate { get; set; }
    public class Handler : IRequestHandler<UpdatePriorityCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<Unit> Handle(UpdatePriorityCommand request, CancellationToken cancellationToken)
      {
        var entity = await _pmContext.Priorities.SingleOrDefaultAsync(u => u.ID == request.ID);
        if (entity == null)
        {
          throw new NotFoundException(nameof(Priority), request.ID);
        }
        entity.Name = request.Name;
        entity.UpdateBy = request.UpdateBy;
        entity.LastUpdate = DateTime.UtcNow;
        await _pmContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
      }
    }
  }
}
