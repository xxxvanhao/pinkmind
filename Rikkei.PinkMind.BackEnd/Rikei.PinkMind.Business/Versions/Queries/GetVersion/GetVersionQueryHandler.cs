using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Versions.Queries.GetVersion
{
  class GetVersionQueryHandler : IRequestHandler<GetVersionQuery, VersionModel>
  {
    private readonly PinkMindContext _pmContext;
    public GetVersionQueryHandler(PinkMindContext pinkMindContext)
    {
      _pmContext = pinkMindContext;
    }
    public async Task<VersionModel> Handle(GetVersionQuery request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Versions.FindAsync(request.ID);

      if (entity == null)
      {
        throw new NotFoundException(nameof(Version), request.ID);
      }

      return VersionModel.Create(entity);
    }
  }
}
