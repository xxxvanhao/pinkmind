using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.TeamDetails.Queries.GetTeamDetail
{
  public class GetTeamDetailQueryHandler : IRequestHandler<GetTeamDetailQuery, TeamDetailModel>
  {
    private readonly PinkMindContext _pmContext;
    public GetTeamDetailQueryHandler(PinkMindContext pinkMindContext)
    {
      _pmContext = pinkMindContext;
    }

    public async Task<TeamDetailModel> Handle(GetTeamDetailQuery request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.TeamDetails.FindAsync(request.ID);
      if (entity == null)
      {
        throw new NotFoundException(nameof(TeamDetail), request.ID);
      }

      return TeamDetailModel.Create(entity);
    }
  }
}
