using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Statuses.Queries
{
  public class GetStatusQueryHandler : IRequestHandler<GetStatusQuery, StatusModel>
  {

    private readonly PinkMindContext _pmContext;
    public GetStatusQueryHandler(PinkMindContext pinkMindContext)
    {
      _pmContext = pinkMindContext;
    }
    public async Task<StatusModel> Handle(GetStatusQuery request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Statuses.FindAsync(request.ID);

      if (entity == null)
      {
        throw new NotFoundException(nameof(Status), request.ID);
      }
      return StatusModel.Create(entity);
    }
  }
}
