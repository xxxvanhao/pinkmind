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

namespace Rikei.PinkMind.Business.Users.Commands.DeleteUser
{
  public class DeleteUserQueryHandler : IRequestHandler<DeleteUserCommand,Unit>
  {
    private readonly PinkMindContext _pmContext;
    public DeleteUserQueryHandler(PinkMindContext pmContext)
    {
      _pmContext = pmContext;
    }
    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Users.FindAsync(request.ID);
      if (entity == null)
      {
        throw new NotFoundException(nameof(User), request.ID);
      }
      var hasTeam = _pmContext.Teams.Any(t => t.ID == entity.ID);
      if (hasTeam)
      {

        throw new DeleteFailureException(nameof(User), request.ID, "There are existing Teams, please get out");
      }
      _pmContext.Users.Remove(entity);
      await _pmContext.SaveChangesAsync();
      return Unit.Value;
    }
  }
}
