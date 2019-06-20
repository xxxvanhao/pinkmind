using AutoMapper;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Rikei.PinkMind.Business.Projects.Queries.GetAllProjects
{
    class GetAllProjectQueryHandler
    {
    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;
    public GetAllProjectQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }

    public async Task<ProjectViewModel> Handle(CancellationToken cancellationToken)
    {
      var Project = from pr in _pmContext.Projects select pr;
      var AllProject = await Project.ToListAsync(cancellationToken);

      var model = new ProjectViewModel
      {
        Projects = _mapper.Map<IEnumerable<ProjectDTO>>(AllProject)
      };
      return model;
      throw new NotImplementedException();
    }
  }
}
