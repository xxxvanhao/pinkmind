using AutoMapper;
using MediatR;
using Rikkei.PinkMind.DAO.Data;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Rikei.PinkMind.Business.Notifies.Queries.GetAll
{
  public class GetAllNotifyQueryHandler : IRequestHandler<GetAllNotifyQuery, NotifyViewModel>
  {
    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;
    public GetAllNotifyQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }

    public async Task<NotifyViewModel> Handle(GetAllNotifyQuery request, CancellationToken cancellationToken)
    {
      var Notifies = from ct in _pmContext.Notifies select ct;
      var AllNotifies = await Notifies.ToListAsync(cancellationToken);
      var tranfItem = new List<NotifyDTO>();
      foreach (var item in AllNotifies)
      {
        var tfitem = new NotifyDTO();
        tfitem.ID = item.ID;
        tfitem.IssueID = item.IssueID;
        tfitem.Status = item.Status;
        tfitem.UserID = item.UserID;
        tranfItem.Add(tfitem);
      }

      var model = new NotifyViewModel
      {
        notifies = _mapper.Map<IEnumerable<NotifyDTO>>(tranfItem)
      };
      return model;
      throw new System.NotImplementedException();
    }
  }
}
