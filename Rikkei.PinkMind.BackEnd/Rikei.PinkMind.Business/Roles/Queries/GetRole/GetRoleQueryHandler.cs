using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Roles.Queries.GetRole
{
  public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, RoleModel>
  {
    private readonly PinkMindContext _pmContext;
    public GetRoleQueryHandler(PinkMindContext pinkMindContext)
    {
      _pmContext = pinkMindContext;
    }
    public async Task<RoleModel> Handle(GetRoleQuery request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Roles.FindAsync(request.ID);

      if (entity == null)
      {
        throw new NotFoundException(nameof(Roles), request.ID);
      }

      return RoleModel.Create(entity);
    }
  }
}
