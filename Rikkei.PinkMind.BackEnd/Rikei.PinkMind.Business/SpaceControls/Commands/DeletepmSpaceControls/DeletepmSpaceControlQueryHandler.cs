using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System.Threading;
using System.Threading.Tasks;
namespace Rikei.PinkMind.Business.SpaceControls.Commands.DeletepmSpaceControls

{
  public class DeletepmSpaceControlQueryHandler : IRequestHandler<DeletepmSpaceControlCommand, Unit>
  {
    private readonly PinkMindContext _pmContext;
    public DeletepmSpaceControlQueryHandler(PinkMindContext pmContext)
    {
      _pmContext = pmContext;
    }

    public async Task<Unit> Handle(DeletepmSpaceControlCommand request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.SpaceControls.FindAsync(request.ID);
      if (entity == null)
      {
        throw new DeleteFailureException(nameof(SpaceControl), request.ID, "Spacecontrol");
      }
      _pmContext.SpaceControls.Remove(entity);
      await _pmContext.SaveChangesAsync();
      return Unit.Value;
      throw new System.NotImplementedException();
    }
  }
}
