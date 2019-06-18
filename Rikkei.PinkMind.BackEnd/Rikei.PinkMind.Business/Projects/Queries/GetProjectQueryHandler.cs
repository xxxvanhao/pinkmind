using Rikkei.PindMind.DAO.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using MediatR;
using Rikkei.PinkMind.DAO.Data;
using System.Threading;
using System.Threading.Tasks;
using Rikei.PinkMind.Business.Exceptions;

namespace Rikei.PinkMind.Business.Projects.Queries
{
  public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ProjectModel>
  {
    private readonly PinkMindContext _pmContext;
    public GetProjectQueryHandler(PinkMindContext pinkMindContext)
    {
      _pmContext = pinkMindContext;
    }
    public async Task<ProjectModel> Handle(GetProjectQuery request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Projects.FindAsync(request.ID);

      if (entity == null)
      {
        throw new NotFoundException(nameof(Project), request.ID);
      }

      return ProjectModel.Create(entity);
    }
  }
}
