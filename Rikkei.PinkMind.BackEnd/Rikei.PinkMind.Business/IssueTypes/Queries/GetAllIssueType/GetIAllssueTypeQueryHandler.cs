using AutoMapper;
using MediatR;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Rikei.PinkMind.Business.IssueTypes.Queries.GetAllIssueType
{
  public class GetIAllssueTypeQueryHandler
  {
    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;
    public GetIAllssueTypeQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }

    public async Task<IssueTypesViewModel> Handle(CancellationToken cancellationToken)
    {
      var ListIssueType = from iss in _pmContext.IssueTypes select iss;
      var AllIssueType = await ListIssueType.ToListAsync(cancellationToken);

      var model = new IssueTypesViewModel
      {
        IssueTypes = _mapper.Map<IEnumerable<IssueTypesDTO>>(AllIssueType)
      };
      return model;
      throw new NotImplementedException();
    }
  }
}
