using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.pmSpaces.Commands.DeletepmSpace
{
  public class DeletepmSpaceQueryHandler : IRequestHandler<DeletepmSpaceCommand, Unit>
  {
    private readonly PinkMindContext _pmContext;
    public DeletepmSpaceQueryHandler(PinkMindContext pmContext)
    {
      _pmContext = pmContext;
    }

    public async Task<Unit> Handle(DeletepmSpaceCommand request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Spaces.FindAsync(request.SpaceID);
      if (entity == null)
      {
        throw new NotFoundException(nameof(Space), request.SpaceID);
      }
      _pmContext.Spaces.Remove(entity);
      await _pmContext.SaveChangesAsync();
      return Unit.Value;
    }
  }
}
