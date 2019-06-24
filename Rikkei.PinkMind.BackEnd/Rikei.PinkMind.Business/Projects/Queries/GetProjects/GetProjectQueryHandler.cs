using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Projects.Queries.GetProjects
{
  public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ProjectViewModel>
  {

    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;
    public GetProjectQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }
    public async Task<ProjectViewModel> Handle(GetProjectQuery request, CancellationToken cancellationToken)
    {
      var project = from td in _pmContext.TeamDetails
                    from tj in _pmContext.TeamJoins
                    join u in _pmContext.Users on td.UserID equals u.ID
                    join t in _pmContext.Teams on new {a=td.TeamID, b=tj.TeamID} equals new {a=t.ID, b=t.ID}
                    join p in _pmContext.Projects on tj.ProjectID equals p.ID
                    where  u.ID == request.userID
                    select p;
      var projectDetails = await project.ToListAsync(cancellationToken);
      
      var model = new ProjectViewModel
      {
        Projects = _mapper.Map<IEnumerable<ProjectDTO>>(projectDetails)
      };

      return model;
    }
  }
}
