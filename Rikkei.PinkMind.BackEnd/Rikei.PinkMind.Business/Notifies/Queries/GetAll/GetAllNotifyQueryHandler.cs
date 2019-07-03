using AutoMapper;
using MediatR;
using Rikkei.PinkMind.DAO.Data;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rikkei.PindMind.DAO.Models;
using System.Net;

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
      var getNotifyList = await _pmContext.Notifies.Where(arr => arr.UserID == request.userID).ToListAsync();

      List<NotifyDTO> notifyList = new List<NotifyDTO>();

      for(int i=0; i < getNotifyList.Count; i++)
      {
        var notify = await _pmContext.ReUpdates.FindAsync(getNotifyList.ElementAt(i).ReupdateID);
        var notifyDTO = new NotifyDTO
        {
          ID = notify.ID,
          ActionName = WebUtility.HtmlDecode(notify.ActionName),
          Content = WebUtility.HtmlDecode(notify.Content),
          Subject = notify.Subject,
          UserName = notify.UserName,
          AvatarPath = notify.AvatarPath,
          Status = false,
          IssueID = getNotifyList.ElementAt(i).IssueID,
          IssueKey = notify.IssueKey,
          ProjectKey = notify.ProjectKey,
          SpaceID = notify.SpaceID,
          UpdateTime = notify.UpdateTime
        };

        notifyList.Add(notifyDTO);
      }
      
      var model = new NotifyViewModel
      {
        notifies = _mapper.Map<IEnumerable<NotifyDTO>>(notifyList)
      };
      return model;
    }
  }
}
