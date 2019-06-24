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

namespace Rikei.PinkMind.Business.Comments.Commands.Delete
{
  public class DeleteCommentQueryHandler : IRequestHandler<DeleteCommentCommand, Unit>
  {
    private readonly PinkMindContext _pmContext;
    public DeleteCommentQueryHandler(PinkMindContext pmContext)
    {
      _pmContext = pmContext;
    }
    public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Users.FindAsync(request.ID);
      if (entity == null)
      {
        throw new DeleteFailureException(nameof(Comment), request.ID, "Not found this ID in Comment");
      }
      var hasTeam = _pmContext.Teams.Any(t => t.ID == entity.ID);
      _pmContext.Users.Remove(entity);
      await _pmContext.SaveChangesAsync();
      return Unit.Value;
    }
  }
}
