using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Priorities.Queries
{
    class GetPriorityQueryHandler : IRequestHandler<GetPriorityQuery, PriorityModel>
  {
    private readonly PinkMindContext _pmContext;
    public GetPriorityQueryHandler(PinkMindContext pinkMindContext)
    {
      _pmContext = pinkMindContext;
    }
    public async Task<PriorityModel> Handle(GetPriorityQuery request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Priorities.FindAsync(request.ID);

      if (entity == null)
      {
        throw new NotFoundException(nameof(Priority), request.ID);
      }

      return PriorityModel.Create(entity);
    }
  }
}
