using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Milestones.Commands.Delete
{
  class DeleteVersionCommandQueryHandler : IRequestHandler<DeleteVersioncommand, Unit>
  {
    private readonly PinkMindContext _pmContext;
    public DeleteVersionCommandQueryHandler(PinkMindContext pmContext)
    {
      _pmContext = pmContext;
    }

    public async Task<Unit> Handle(DeleteVersioncommand request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Milestones.FindAsync(request.ID);
      if (entity == null)
      {
        throw new DeleteFailureException(nameof(Milestone), request.ID, "Milestone");
      }
      _pmContext.Milestones.Remove(entity);
      await _pmContext.SaveChangesAsync();
      return Unit.Value;
      throw new System.NotImplementedException();
    }
  }
}
