using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Notifies.Queries
{
  public class GetNotifyQueryHandler : IRequestHandler<GetNotifyQuery, NotifyModel>
  {
    private readonly PinkMindContext _pmContext;
    public GetNotifyQueryHandler(PinkMindContext pinkMindContext)
    {
      _pmContext = pinkMindContext;
    }
    public async Task<NotifyModel> Handle(GetNotifyQuery request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Notifies.FindAsync(request.ID);

      if (entity == null)
      {
        throw new NotFoundException(nameof(Notify), request.ID);
      }

      return NotifyModel.Create(entity);
    }
  }
}
