using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Teams.Commands.Delete
{
  class DeleteTeamQueryHandler
  {
    private readonly PinkMindContext _pmContext;
    public DeleteTeamQueryHandler(PinkMindContext pmContext)
    {
      _pmContext = pmContext;
    }
    public async Task<Unit> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Teams.FindAsync(request.ID);
      if (entity == null)
      {
        throw new NotFoundException(nameof(Teams), request.ID);
      }
      var hasTeam = _pmContext.Teams.Any(t => t.ID == entity.ID);
      if (hasTeam)
      {

        throw new DeleteFailureException(nameof(Team), request.ID, "There are existing Teams, please get out");
      }
      _pmContext.Teams.Remove(entity);
      await _pmContext.SaveChangesAsync();
      return Unit.Value;
    }
  }
}
