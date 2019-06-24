using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Milestones.Queries.GetMileston
{
  public class GetMilestoneQueryHandler : IRequestHandler<GetMilestoneQuery, MilestonModel>
  {
    private readonly PinkMindContext _pmContext;
    public GetMilestoneQueryHandler(PinkMindContext pinkMindContext)
    {
      _pmContext = pinkMindContext;
    }
    public async Task<MilestonModel> Handle(GetMilestoneQuery request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Milestones.FindAsync(request.ID);

      if (entity == null)
      {
        throw new NotFoundException(nameof(Roles), request.ID);
      }

      return MilestonModel.Create(entity);
    }
  }
}
