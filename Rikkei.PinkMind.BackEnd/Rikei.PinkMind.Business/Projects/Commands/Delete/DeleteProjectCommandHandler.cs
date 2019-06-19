using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Projects.Commands.Delete
{
  class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
  {
    private readonly PinkMindContext _pmContext;
    public DeleteProjectCommandHandler(PinkMindContext pmContext)
    {
      _pmContext = pmContext;
    }

    public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Projects.FindAsync(request.ID);
      if (entity == null)
      {
        throw new DeleteFailureException(nameof(Project), request.ID, "Project ");
      }
      _pmContext.Projects.Remove(entity);
      await _pmContext.SaveChangesAsync();
      return Unit.Value;
      throw new System.NotImplementedException();
    }
  }
}
