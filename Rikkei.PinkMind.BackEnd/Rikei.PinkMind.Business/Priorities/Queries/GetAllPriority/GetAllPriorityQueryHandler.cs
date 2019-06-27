using AutoMapper;
using MediatR;
using Rikkei.PinkMind.DAO.Data;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Rikei.PinkMind.Business.Priorities.Queries.GetAllPriority
{
  public class GetAllPriorityQueryHandler : IRequestHandler<GetAllPriorityQuery, PriorityViewModel>
  {

    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;
    public GetAllPriorityQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }

    public async Task<PriorityViewModel> Handle(GetAllPriorityQuery request, CancellationToken cancellationToken)
    {
      var priorities = from ct in _pmContext.Priorities select ct;
      var allPriorities = await priorities.ToListAsync(cancellationToken);
      var tranfItem = new List<PriorityDTO>();
      foreach (var item in allPriorities)
      {
        var tfitem = new PriorityDTO();
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

      var model = new PriorityViewModel
      {
        priorities = _mapper.Map<IEnumerable<PriorityDTO>>(tranfItem)
      };
      return model;
    }
  }
}
