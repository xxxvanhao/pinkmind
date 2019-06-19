using MediatR;
using Microsoft.EntityFrameworkCore;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Teams.Commands.Update
{
  public class UpdateTeamCommand : IRequest
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public class Handler : IRequestHandler<UpdateTeamCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }

      public async Task<Unit> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
      {
        var entity = await _pmContext.Teams.SingleOrDefaultAsync(t => t.ID == request.ID);
        if (entity == null)
        {
          throw new NotFoundException(nameof(Teams), request.ID);
        }
        entity.Name = request.Name;
        entity.CreateAt = DateTime.UtcNow;
        entity.UpdateBy = request.UpdateBy;
        entity.LastUpdate = DateTime.UtcNow;
        entity.DelFlag = !request.DelFlag ? true : false;

        await _pmContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
      }
    }
  }
}
