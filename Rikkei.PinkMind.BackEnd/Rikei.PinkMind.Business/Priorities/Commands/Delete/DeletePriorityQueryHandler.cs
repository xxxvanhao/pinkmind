using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Priorities.Commands.Delete
{
  class DeletePriorityQueryHandler : IRequestHandler<DeletePriorityCommand, Unit>
  {
    private readonly PinkMindContext _pmContext;
    public DeletePriorityQueryHandler(PinkMindContext pmContext)
    {
      _pmContext = pmContext;
    }
    public async Task<Unit> Handle(DeletePriorityCommand request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Priorities.FindAsync(request.ID);
      if (entity == null)
      {
        throw new NotFoundException(nameof(Priority), request.ID);
      }
     
      _pmContext.Priorities.Remove(entity);
      await _pmContext.SaveChangesAsync();
      return Unit.Value;
    }
  }
}
