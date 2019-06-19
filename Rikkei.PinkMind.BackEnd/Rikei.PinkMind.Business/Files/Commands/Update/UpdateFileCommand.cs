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

namespace Rikei.PinkMind.Business.Files.Commands.Update
{
  public class UpdateFileCommand : IRequest
  {
    public int ID { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public class Handler : IRequestHandler<UpdateFileCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<Unit> Handle(UpdateFileCommand request, CancellationToken cancellationToken)
      {
        var entity = await _pmContext.Files.SingleOrDefaultAsync(u => u.ID == request.ID);
        if (entity == null)
        {
          throw new NotFoundException(nameof(File), request.ID);
        }

        entity.ID = request.ID;
        entity.DelFlag = false;
        entity.LastUpdate = DateTime.UtcNow;
        await _pmContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
      }
    }
  }
}
