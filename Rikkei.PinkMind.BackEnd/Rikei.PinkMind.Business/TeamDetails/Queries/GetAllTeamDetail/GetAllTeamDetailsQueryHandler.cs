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
  public class GetAllTeamDetailsQueryHandler: IRequestHandler<GetAllTeamDetailsQuery, TeamDetailsViewModel>
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
      var teamDetails = from td in _pmContext.TeamDetails select td;
      var allTeamDetails = await teamDetails.Where(td => td.TeamID == request.ID).ToListAsync(cancellationToken);

      var model = new TeamDetailsViewModel
      {
        TeamDetails = _mapper.Map<IEnumerable<TeamDetailsDTO>>(allTeamDetails)
      };

      return model;
    }
  }
}
