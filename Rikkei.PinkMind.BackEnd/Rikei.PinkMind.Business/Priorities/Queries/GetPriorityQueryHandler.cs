using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Priorities.Queries.GetAllPriority
{
  public class GetAllPriorityQueryHandler : IRequestHandler<GetAllPriorityQuery, PriorityViewModel>
  {
    private readonly PinkMindContext _pmContext;
  public GetAllPriorityQueryHandler(PinkMindContext pinkMindContext)
  {
    _pmContext = pinkMindContext;
  }
  public async Task<PriorityViewModel> Handle(GetAllPriorityQuery request, CancellationToken cancellationToken)
  {
    var entity = await _pmContext.Priorities.FindAsync(request.ID);

    if (entity == null)
    {
      throw new NotFoundException(nameof(Priority), request.ID);
    }

    return PriorityViewModel.Create(entity);
  }
}
}
