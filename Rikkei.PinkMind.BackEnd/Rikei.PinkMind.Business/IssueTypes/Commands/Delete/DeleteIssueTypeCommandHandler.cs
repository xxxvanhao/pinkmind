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

namespace Rikei.PinkMind.Business.IssueTypes.Commands.Delete
{
  public class DeleteIssueTypeCommandHandler : IRequestHandler<DeleteIssueTypeCommand, Unit>
  {
    private readonly PinkMindContext _pmContext;
    public DeleteIssueTypeCommandHandler(PinkMindContext pmContext)
    {
      _pmContext = pmContext;
    }
    public async Task<Unit> Handle(DeleteIssueTypeCommand request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.IssueTypes.FindAsync(request.ID);
      if (entity == null)
      {
        throw new NotFoundException(nameof(IssueType), request.ID);
      }           
      _pmContext.IssueTypes.Remove(entity);
      await _pmContext.SaveChangesAsync();
      return Unit.Value;
    }
  }
}
