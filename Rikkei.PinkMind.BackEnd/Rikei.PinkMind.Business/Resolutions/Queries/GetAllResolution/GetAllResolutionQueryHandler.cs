using AutoMapper;
using MediatR;
using Rikkei.PinkMind.DAO.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Rikei.PinkMind.Business.Resolutions.Queries.GetAllResolution
{
    class GetAllResolutionQueryHandler : IRequestHandler<GetAllResolutionQuery, ResolutionViewModel>
  {

    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;
    public GetAllResolutionQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }

    public async Task<ResolutionViewModel> Handle(GetAllResolutionQuery request, CancellationToken cancellationToken)
    {
      var Priorities = from ct in _pmContext.Priorities select ct;
      var AllPriorities = await Priorities.ToListAsync(cancellationToken);
      var tranfItem = new List<ResolutionDTO>();
      foreach (var item in AllPriorities)
      {
        var tfitem = new ResolutionDTO();
        tfitem.ID = item.ID;
        tfitem.LastUpdate = item.LastUpdate;
        tfitem.Name = item.Name;
        tfitem.UpdateBy = item.UpdateBy;
        tfitem.CheckUpdate = item.CheckUpdate;
        tfitem.CreateAt = item.CreateAt;
        tfitem.CreateBy = item.CreateBy;
        tfitem.DelFlag = item.DelFlag;
        tranfItem.Add(tfitem);
      }

      var model = new ResolutionViewModel
      {
        resolutions = _mapper.Map<IEnumerable<ResolutionDTO>>(tranfItem)
      };
      return model;
      throw new System.NotImplementedException();
    }
  }
}
