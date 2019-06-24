using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Issues.Commands.Delete
{
  public class DeleteIssueCommandHandler : IRequestHandler<DeleteIssueCommand, Unit>

  {
    private readonly PinkMindContext _pmContext;
    public DeleteIssueCommandHandler(PinkMindContext pmContext)
    {
      _pmContext = pmContext;
    }

    public async Task<Unit> Handle(DeleteIssueCommand request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Issues.FindAsync(request.ID);
      if (entity == null)
      {
        throw new DeleteFailureException(nameof(Issue), request.ID, "Not found this ID in Issue");
      }
      _pmContext.Issues.Remove(entity);
      await _pmContext.SaveChangesAsync();
      return Unit.Value;
      throw new System.NotImplementedException();
    }
  }
}
