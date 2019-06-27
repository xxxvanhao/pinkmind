using MediatR;
using Rikkei.PinkMind.DAO.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using AutoMapper;
using System.Collections.Generic;

namespace Rikei.PinkMind.Business.IssueTypes.Queries.GetAllIssueType
{
  public class GetIAllssueTypeQueryHandler : IRequestHandler<GetIAllssueTypeQuery, IssueTypesViewModel>
  {

    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;
    public GetIAllssueTypeQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }

    public async Task<IssueTypesViewModel> Handle(GetIAllssueTypeQuery request, CancellationToken cancellationToken)
    {
      var IssueTypes = from isst in _pmContext.IssueTypes select isst;
      var AllIssueTypes = await IssueTypes.ToListAsync(cancellationToken);
      var tranfItem = new List<IssueTypesDTO>();
      foreach (var item in AllIssueTypes)
      {
        var tfitem = new IssueTypesDTO();
        tfitem.ID = item.ID;
        tfitem.Name = item.Name;
        tfitem.BackgroundColor = item.BackgroundColor;
        tfitem.CheckUpdate = item.CheckUpdate;
        tfitem.CreateAt = item.CreateAt;
        tfitem.CreateBy = item.CreateBy;
        tfitem.DelFlag = item.DelFlag;
        tfitem.UpdateBy = item.UpdateBy;
        tfitem.LastUpdate = item.LastUpdate;
        tranfItem.Add(tfitem);
      }

      var model = new IssueTypesViewModel
      {
        IssueTypes = _mapper.Map<IEnumerable<IssueTypesDTO>>(tranfItem)
      };
      return model;
    }
  }
}

