using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.ReUpdate.GetDetails
{
  public class GetReUpdateQueryHandler : IRequestHandler<GetReUpdateQuery, ReUpdateViewModel>
  {
    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;
    public GetReUpdateQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }
    public async Task<ReUpdateViewModel> Handle(GetReUpdateQuery request, CancellationToken cancellationToken)
    {
      var userDetails = await _pmContext.Users.FindAsync(request.userID);
      var reUpdateList = await _pmContext.ReUpdates.Where(ru => ru.SpaceID == userDetails.SpaceID).ToListAsync(cancellationToken);

      var model = new ReUpdateViewModel
      {
        ReUpdateDTOs = _mapper.Map<IEnumerable<ReUpdateDTO>>(reUpdateList)
      };

      return model;
    }
  }
}
