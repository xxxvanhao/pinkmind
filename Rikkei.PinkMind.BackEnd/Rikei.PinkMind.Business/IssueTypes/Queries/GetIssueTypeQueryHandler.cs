using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.IssueTypes.Queries
{
  public class GetIssueTypeQueryHandler : IRequestHandler<GetIssueTypeQuery, IssueTypeModel>
  {
    private readonly PinkMindContext _pmContext;
    public GetIssueTypeQueryHandler(PinkMindContext pinkMindContext)
    {
      _pmContext = pinkMindContext;
    }
    public async Task<IssueTypeModel> Handle(GetIssueTypeQuery request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.IssueTypes.FindAsync(request.ID);

      if (entity == null)
      {
        throw new NotFoundException(nameof(IssueType), request.ID);
      }

      return IssueTypeModel.Create(entity);
    }
  }
}
