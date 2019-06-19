using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Categories.Commands.Delete
{
  public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
  {
    private readonly PinkMindContext _pmContext;
    public DeleteCategoryCommandHandler(PinkMindContext pmContext)
    {
      _pmContext = pmContext;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Categories.FindAsync(request.ID);
      if (entity == null)
      {
        throw new DeleteFailureException(nameof(Category), request.ID, "Issue not found");
      }
      _pmContext.Categories.Remove(entity);
      await _pmContext.SaveChangesAsync();
      return Unit.Value;
      throw new System.NotImplementedException();
    }
  }
}
