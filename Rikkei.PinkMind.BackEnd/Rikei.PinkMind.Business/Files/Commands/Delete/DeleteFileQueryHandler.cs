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

namespace Rikei.PinkMind.Business.Files.Commands.Delete
{
  public class DeleteFileQueryHandler : IRequestHandler<DeleteFileCommand, Unit>
  {
    private readonly PinkMindContext _pmContext;
  public DeleteFileQueryHandler(PinkMindContext pmContext)
  {
    _pmContext = pmContext;
  }
  public async Task<Unit> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
  {
    var entity = await _pmContext.Files.FindAsync(request.ID);
    if (entity == null)
    {
      throw new NotFoundException(nameof(File), request.ID);
    }
    _pmContext.Files.Remove(entity);
    await _pmContext.SaveChangesAsync();
    return Unit.Value;
  }
}
}
