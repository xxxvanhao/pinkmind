using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Versions.Queries.GetAllVersions
{
  public class GetAllVersionQueryHandler
  {
    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;
    public GetAllVersionQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }

    public async Task<VersionViewModel> Handle(CancellationToken cancellationToken)
    {
      var Version = from vs in _pmContext.Versions select vs;
      var AllVersions = await Version.ToListAsync(cancellationToken);

      var model = new VersionViewModel
      {
        Versions = _mapper.Map<IEnumerable<VersionDTO>>(AllVersions)
      };
      return model;
      throw new NotImplementedException();
    }
  }
}
