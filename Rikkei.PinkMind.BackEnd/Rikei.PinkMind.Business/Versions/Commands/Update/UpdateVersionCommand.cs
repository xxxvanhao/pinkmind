using MediatR;
using Microsoft.EntityFrameworkCore;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Versions.Commands.Update
{
  public class UpdateVersionCommand : IRequest
  {
    public long ID { get; set; }
    public string Name { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public string CheckUpdate { get; set; }
    public class Handler : IRequestHandler<UpdateVersionCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }

      public async Task<Unit> Handle(UpdateVersionCommand request, CancellationToken cancellationToken)
      {
        var entity = await _pmContext.Versions.SingleOrDefaultAsync(u => u.ID == request.ID);
        if (entity == null)
        {
          throw new NotFoundException(nameof(Rikkei.PindMind.DAO.Models.Version), request.ID);
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
