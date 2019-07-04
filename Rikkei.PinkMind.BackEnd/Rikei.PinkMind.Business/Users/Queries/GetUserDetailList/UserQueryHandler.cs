using AutoMapper;
using MediatR;
using Rikkei.PinkMind.DAO.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Rikei.PinkMind.Business.Users.Queries.GetUserDetailList
{
  public class UserQueryHandler : IRequestHandler<UserQuery, UserViewModel>
  {

    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;
    public UserQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }

    public async Task<UserViewModel> Handle(UserQuery request, CancellationToken cancellationToken)
    {
      var users = from ct in _pmContext.Users select ct;
      var AllUser = await users.ToListAsync(cancellationToken);

      var model = new UserViewModel
      {
        users = _mapper.Map<IEnumerable<UserDTO>>(AllUser)
      };

      return model;
      throw new System.NotImplementedException();
    }
  }
}
