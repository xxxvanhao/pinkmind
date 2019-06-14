using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Users.Queries.GetUserDetail
{
  public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetailModel>
  {

    private readonly PinkMindContext _pmContext;
    public GetUserDetailQueryHandler(PinkMindContext pinkMindContext)
    {
      _pmContext = pinkMindContext;
    }
    public async Task<UserDetailModel> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Users.FindAsync(request.ID);

      if(entity == null) {
      throw new NotFoundException(nameof(User), request.ID);
      }

      return UserDetailModel.Create(entity);
    }
  }
}
