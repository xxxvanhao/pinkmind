using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.SpaceControls.Queries.GetpmSpaceControl
{
  class GetpmSpaceControlQueryHandler : IRequestHandler<GetpmSpaceControlQuery, SpaceControlModel>
  {
    private readonly PinkMindContext _pmContext;
    public GetpmSpaceControlQueryHandler(PinkMindContext pinkMindContext)
    {
      _pmContext = pinkMindContext;
    }
    public async Task<SpaceControlModel> Handle(GetpmSpaceControlQuery request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.SpaceControls.FindAsync(request.ID);
      if (entity == null)
      {
        throw new NotFoundException(nameof(SpaceControl), request.ID);
      }

      return SpaceControlModel.Create(entity);
    }
  }
}
