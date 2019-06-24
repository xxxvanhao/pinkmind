using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Statuses.Commands.Delete
{
  public class DeleteStatusQueryHandler : IRequestHandler<DeleteStatusCommand, Unit>
  {
    private readonly PinkMindContext _pmContext;
    public DeleteStatusQueryHandler(PinkMindContext pmContext)
    {
      _pmContext = pmContext;
    }
    public async Task<Unit> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Statuses.FindAsync(request.ID);
      if (entity == null)
      {
        throw new NotFoundException(nameof(Status), request.ID);
      }
      _pmContext.Statuses.Remove(entity);
      await _pmContext.SaveChangesAsync(cancellationToken);
      return Unit.Value;
    }
  }
}
