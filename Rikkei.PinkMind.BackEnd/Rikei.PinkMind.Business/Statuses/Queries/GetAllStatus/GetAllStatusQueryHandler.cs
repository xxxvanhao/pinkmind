using AutoMapper;
using MediatR;
using Rikkei.PinkMind.DAO.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Rikei.PinkMind.Business.Statuses.Queries.GetAllStatus
{
  class GetAllStatusQueryHandler : IRequestHandler<GetAllStatusQuery, StatusViewModel>
  {

    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;
    public GetAllStatusQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }

    public async Task<StatusViewModel> Handle(GetAllStatusQuery request, CancellationToken cancellationToken)
    {
      var Statuses = from ct in _pmContext.Statuses select ct;
      var AllStatuses = await Statuses.ToListAsync(cancellationToken);
      var tranfItem = new List<StatusDTO>();
      foreach (var item in AllStatuses)
      {
        var tfitem = new StatusDTO();
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

      var model = new StatusViewModel
      {
        statuses = _mapper.Map<IEnumerable<StatusDTO>>(tranfItem)
      };
      return model;
      throw new System.NotImplementedException();
    }
  }
}
