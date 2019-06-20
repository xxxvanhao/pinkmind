using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikei.PinkMind.Business.Users.Queries.GetUserDetail;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.pmSpaces.Queries.GetpmSpace
{
  public class GetpmSpaceQueryHandler : IRequestHandler<GetpmSpaceQuery, SpaceModel>
  {
    private readonly PinkMindContext _pmContext;
    public GetpmSpaceQueryHandler(PinkMindContext pinkMindContext)
    {
      _pmContext = pinkMindContext;
    }
    public async Task<SpaceModel> Handle(GetpmSpaceQuery request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Spaces.FindAsync(request.SpaceID);
      if (entity == null)
      {
        throw new NotFoundException(nameof(Space), request.SpaceID);
      }

      return SpaceModel.Create(entity);
    }
  }
}
