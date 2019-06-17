using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Teams.Queries.GetTeams
{
    class GetTeamQueryHandler : IRequestHandler<GetTeamControlQuery, GetTeamModel>
  {

    private readonly PinkMindContext _pmContext;
    public GetTeamQueryHandler(PinkMindContext pinkMindContext)
    {
      _pmContext = pinkMindContext;
    }
    public async Task<GetTeamModel> Handle(GetTeamControlQuery request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Teams.FindAsync(request.ID);

      if (entity == null)
      {
        throw new NotFoundException(nameof(Teams), request.ID);
      }
      return GetTeamModel.Create(entity);
    }
  }
}
