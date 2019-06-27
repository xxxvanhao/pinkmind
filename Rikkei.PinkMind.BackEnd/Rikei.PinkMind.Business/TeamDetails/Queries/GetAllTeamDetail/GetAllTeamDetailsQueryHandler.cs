using MediatR;
using System.Linq;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Collections.Generic;

namespace Rikei.PinkMind.Business.TeamDetails.Queries.GetAllTeamDetail
{
  public class GetAllTeamDetailsQueryHandler : IRequestHandler<GetAllTeamDetailsQuery, TeamDetailsViewModel>
  {

    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;
    public GetAllTeamDetailsQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }
    public async Task<TeamDetailsViewModel> Handle(GetAllTeamDetailsQuery request, CancellationToken cancellationToken)
    {
      var teamDetails = from td in _pmContext.TeamDetails
                        select new TeamDetailsDTO
                        {
                          ID = td.ID,
                          UserID = td.UserID,
                          AvatarPath = td.User.PictureUrl,
                          UserName = $"{td.User.FirstName} {td.User.LastName}",
                          TeamID = td.TeamID,
                          TeamName = td.Team.Name,
                          RoleID = td.RoleID,
                          RoleName = td.Role.Name,
                          JoinedOn = td.JoinedOn,
                          AddBy = td.AddBy,
                          DelFlag = td.DelFlag,
                        };
      var allTeamDetails = await teamDetails.Where(td => td.TeamName == request.TeamName).ToListAsync(cancellationToken);

      var model = new TeamDetailsViewModel
      {
        TeamDetails = _mapper.Map<IEnumerable<TeamDetailsDTO>>(allTeamDetails)
      };

      return model;
    }
  }
}
