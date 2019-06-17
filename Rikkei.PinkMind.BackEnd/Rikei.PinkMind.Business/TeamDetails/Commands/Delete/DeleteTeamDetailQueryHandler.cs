using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.TeamDetails.Commands.Delete
{
  class DeleteTeamDetailQueryHandler : IRequestHandler<DeleteTeamDetailCommand, Unit>
  {
    private readonly PinkMindContext _pmContext;
    public DeleteTeamDetailQueryHandler(PinkMindContext pmContext)
    {
      _pmContext = pmContext;
    }
    public async Task<Unit> Handle(DeleteTeamDetailCommand request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.TeamDetails.FindAsync(request.ID);
      if (entity == null)
      {
        throw new NotFoundException(nameof(TeamDetails), request.ID);
      }      
      _pmContext.TeamDetails.Remove(entity);
      await _pmContext.SaveChangesAsync();
      return Unit.Value;
    }
  }
}
