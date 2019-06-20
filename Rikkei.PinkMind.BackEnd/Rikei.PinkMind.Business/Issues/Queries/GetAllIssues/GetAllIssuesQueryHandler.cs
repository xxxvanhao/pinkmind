using AutoMapper;
using MediatR;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Rikei.PinkMind.Business.Issues.Queries.GetAllIssues
{
  class GetAllIssuesQueryHandler : IRequestHandler<GetAllIssuesQuery, IssuesViewModel>
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
      var ListIssues = from issue in _pmContext.Issues select issue;
      var AllIssue = await ListIssues.Where(td => td.ProjectID == request.ID).ToListAsync(cancellationToken);

      var model = new IssuesViewModel
      {
        Issues = _mapper.Map<IEnumerable<IssuesDTO>>(AllIssue)
      };

      return model;
    }
  }
}
