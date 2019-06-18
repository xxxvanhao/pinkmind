using MediatR;
using System.Linq;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Rikei.PinkMind.Business.SpaceControls.Queries.GetpmSpaceControl
{
  public class GetpmSpaceControlQueryHandler : IRequestHandler<GetpmSpaceControlQuery, SpaceControlModel>
  {
    private readonly PinkMindContext _pmContext;
    public GetpmSpaceControlQueryHandler(PinkMindContext pinkMindContext)
    {
      _pmContext = pinkMindContext;
    }
    public async Task<SpaceControlModel> Handle(GetpmSpaceControlQuery request, CancellationToken cancellationToken)

    {
      var spaceControl = from sc in _pmContext.SpaceControls select sc;
      var entity = await spaceControl.Where(sc => sc.ControlBy == request.userId).SingleOrDefaultAsync();
      if (entity == null)
      {
        throw new NotFoundException(nameof(SpaceControl), request.userId);
      }

      return SpaceControlModel.Create(entity);
    }
  }
}
