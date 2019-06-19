using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Issues.Queries
{
    class GetIssueQueryHandler : IRequestHandler<GetIssueQuery, IssueModel>
  {
    private readonly PinkMindContext _pmContext;
    public GetIssueQueryHandler(PinkMindContext pinkMindContext)
    {
      _pmContext = pinkMindContext;
    }
    public async Task<IssueModel> Handle(GetIssueQuery request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Issues.FindAsync(request.ID);

      if (entity == null)
      {
        throw new NotFoundException(nameof(Issue), request.ID);
      }

      return IssueModel.Create(entity);
    }
  }
}
