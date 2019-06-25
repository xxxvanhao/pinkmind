using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
      List<ReUpdateSpace> reUpdateList = new List<ReUpdateSpace>();

      var project = from td in _pmContext.TeamDetails
                    from tj in _pmContext.TeamJoins
                    join u in _pmContext.Users on td.UserID equals u.ID
                    join t in _pmContext.Teams on new { a = td.TeamID, b = tj.TeamID } equals new { a = t.ID, b = t.ID }
                    join p in _pmContext.Projects on tj.ProjectID equals p.ID
                    where u.ID == request.userID
                    select p.ID;
      var projectNameDetails = await project.ToListAsync(cancellationToken);

      for (int i = 0; i < projectNameDetails.Count; i++)
      {
        var reUpdate = await _pmContext.ReUpdates.Where(ru => ru.SpaceID == userDetails.SpaceID && ru.ProjectKey == projectNameDetails.ElementAt(i)).OrderByDescending(d => d.UpdateTime).ToListAsync(cancellationToken);
        foreach (ReUpdateSpace item in reUpdate)
        {
          item.ActionName = WebUtility.HtmlDecode(item.ActionName);
          item.Content = WebUtility.HtmlDecode(item.Content);
          reUpdateList.Add(item);
        }
      }

      var model = new ReUpdateViewModel
      {
        ReUpdateDTOs = _mapper.Map<IEnumerable<ReUpdateDTO>>(reUpdateList)
      };

      return model;
    }
  }
}
