using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Notifies.Commands.Delete
{
  public class DeleteNotifyQueryHandler : IRequestHandler<DeleteNotifyCommand, Unit>
  {
    private readonly PinkMindContext _pmContext;
    public DeleteNotifyQueryHandler(PinkMindContext pmContext)
    {
      _pmContext = pmContext;
    }
    public async Task<Unit> Handle(DeleteNotifyCommand request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Notifies.FindAsync(request.ID);
      if (entity == null)
      {
        throw new NotFoundException(nameof(Notify), request.ID);
      }      
      _pmContext.Notifies.Remove(entity);
      await _pmContext.SaveChangesAsync();
      return Unit.Value;
    }
  }
}