using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Resolutions.Queries
{
  public class GetResolutionQueryHandler : IRequestHandler<GetResolutionQuery, ResolutionModel>
  {
    private readonly PinkMindContext _pmContext;
    public GetResolutionQueryHandler(PinkMindContext pinkMindContext)
    {
      _pmContext = pinkMindContext;
    }
    public async Task<ResolutionModel> Handle(GetResolutionQuery request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Resolutions.FindAsync(request.ID);

      if (entity == null)
      {
        throw new NotFoundException(nameof(Resolution), request.ID);
      }

      return ResolutionModel.Create(entity);
    }
  }
}
