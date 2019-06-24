using MediatR;
using Microsoft.EntityFrameworkCore;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Resolutions.Commands.Update
{
  public class UpdateResolutionCommand : IRequest
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public int UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public string CheckUpdate { get; set; }
    public class Handler : IRequestHandler<UpdateResolutionCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }

      public async Task<Unit> Handle(UpdateResolutionCommand request, CancellationToken cancellationToken)
      {
        var entity = await _pmContext.Resolutions.SingleOrDefaultAsync(u => u.ID == request.ID);
        if (entity == null)
        {
          throw new NotFoundException(nameof(Resolution), request.ID);
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
