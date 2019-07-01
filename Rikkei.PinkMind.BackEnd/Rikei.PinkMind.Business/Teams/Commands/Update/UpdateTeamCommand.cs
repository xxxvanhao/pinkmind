using MediatR;
using Microsoft.EntityFrameworkCore;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Teams.Commands.Update
{
  public class UpdateTeamCommand : IRequest
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
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
        entity.UpdateBy = request.UpdateBy;
        entity.LastUpdate = DateTime.Now;
        await _pmContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
      }
    }
  }
}
