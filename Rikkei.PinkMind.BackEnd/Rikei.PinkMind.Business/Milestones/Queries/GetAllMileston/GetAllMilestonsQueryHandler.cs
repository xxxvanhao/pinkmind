using AutoMapper;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Rikei.PinkMind.Business.Milestones.Queries.GetAllMileston
{
  public class GetAllMilestonsQueryHandler 
  { 
    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;
    public GetAllMilestonsQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }

    public async Task<MilestonsViewModel> Handle(CancellationToken cancellationToken)
    {
      var Milestons = from mile in _pmContext.Milestones select mile;
      var AllMilestons = await Milestons.ToListAsync(cancellationToken);

      var model = new MilestonsViewModel
      {
        Milestons = _mapper.Map<IEnumerable<MilestonsDTO>>(AllMilestons)
      };
      return model;
      throw new NotImplementedException();
    }
  }
}
