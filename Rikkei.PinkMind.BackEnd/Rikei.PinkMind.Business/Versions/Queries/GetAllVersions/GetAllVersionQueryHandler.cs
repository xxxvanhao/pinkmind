using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Versions.Queries.GetAllVersions
{
  public class GetAllVersionQueryHandler : IRequestHandler<GetAllVersionQuery, VersionViewModel>
  {

    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;
    public GetAllVersionQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }

    public async Task<VersionViewModel> Handle(GetAllVersionQuery request, CancellationToken cancellationToken)
    {
      var Version = from ct in _pmContext.Versions select ct;
      var AllVersion = await Version.ToListAsync(cancellationToken);
      var tranfItem = new List<VersionDTO>();
      foreach (var item in AllVersion)
      {
        var tfitem = new VersionDTO();
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

      var model = new VersionViewModel
      {
        Versions = _mapper.Map<IEnumerable<VersionDTO>>(tranfItem)
      };
      return model;
      throw new System.NotImplementedException();
    }
  }
}
