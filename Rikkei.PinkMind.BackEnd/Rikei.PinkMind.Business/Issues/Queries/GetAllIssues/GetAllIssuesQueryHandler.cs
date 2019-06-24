using AutoMapper;
using MediatR;
using Rikkei.PinkMind.DAO.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Rikei.PinkMind.Business.Issues.Queries.GetAllIssues
{
  public class GetAllIssuesQueryHandler : IRequestHandler<GetAllIssuesQuery, IssuesViewModel>
  {
    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;
    public GetAllIssuesQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }
    public async Task<IssuesViewModel> Handle(GetAllIssuesQuery request, CancellationToken cancellationToken)
    {
      var Issue = from iss in _pmContext.Issues select iss;
      var All = await Issue.ToListAsync(cancellationToken);

      var model = new IssuesViewModel
      {
        Issues = _mapper.Map<IEnumerable<IssuesDTO>>(All)
      };

      return model;
    }
  }
}
