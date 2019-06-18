using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Roles.Commands.Delete
{
  public class DeleteRoleCommandQueryHandler : IRequestHandler<DeleteRoleCommand, Unit>
  {
    private readonly PinkMindContext _pmContext;
    public DeleteRoleCommandQueryHandler(PinkMindContext pmContext)
    {
      _pmContext = pmContext;
    }

    public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Roles.FindAsync(request.ID);
      if (entity == null)
      {
        throw new DeleteFailureException(nameof(Role), request.ID, "Role");
      }
      _pmContext.Roles.Remove(entity);
      await _pmContext.SaveChangesAsync();
      return Unit.Value;
      throw new System.NotImplementedException();
    }
  }
}
