using AutoMapper;
using MediatR;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Users.Queries.Search
{
    public class GetSearchUserQueryHandler : IRequestHandler<GetSearchUserQuery, SearchUserViewModel>
  {
    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;
    public GetSearchUserQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }
    public async Task<SearchUserViewModel> Handle(GetSearchUserQuery request, CancellationToken cancellationToken)
    {
      var user = from us in _pmContext.Users
                 select new
                 {
                   us.ID,
                   us.FullName
                 };
      var ListUser = _pmContext.Users.Where(x => x.FullName.Contains(request.key)).ToList();
      var modelUser = new List<SearchUserDTO>();
      foreach (var item in ListUser)
      {
        var tfItem = new SearchUserDTO();
        tfItem.ID = item.ID;
        tfItem.FullName = item.FullName;
        modelUser.Add(tfItem);
      }

      var model = new SearchUserViewModel
      {
        searchUsers = _mapper.Map<IEnumerable<SearchUserDTO>>(modelUser)
      };

      return model;
    }
  }
}
