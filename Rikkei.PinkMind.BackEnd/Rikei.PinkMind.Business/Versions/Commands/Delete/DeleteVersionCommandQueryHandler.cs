using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PinkMind.DAO.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Versions.Commands.Delete
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
      var entity = await _pmContext.Versions.FindAsync(request.ID);
      if (entity == null)
      {
        throw new DeleteFailureException(nameof(Rikkei.PindMind.DAO.Models.Version), request.ID, "Milestone");
      }
      _pmContext.Versions.Remove(entity);
      await _pmContext.SaveChangesAsync();
      return Unit.Value;
      throw new System.NotImplementedException();
    }
  }
}
