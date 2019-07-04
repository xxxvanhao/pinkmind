using MediatR;
using System.Linq;
using Rikkei.PinkMind.DAO.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Collections.Generic;
using Rikei.PinkMind.Business.Comments.Comments.GetAllComment;

namespace Rikei.PinkMind.Business.Comments.Queries.GetAllComment
{
  public class GetAllCommentsQueryHandler: IRequestHandler<GetAllCommentsQuery, CommentsViewModel>
  {
    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;
    public GetAllCommentsQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }
    public async Task<CommentsViewModel> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
    {
      var user = from us in _pmContext.Users
                 select new
                 {
                   us.ID,
                   us.FullName,
                   us.PictureUrl
                 };
      var ListUser = _pmContext.Users.ToList();

      var Comments = from cm in _pmContext.Comments
                     select new
                     {
                       cm.ID,
                       cm.Content,
                       cm.CreateAt,
                       cm.CreateBy,
                       cm.UpdateBy,
                       cm.LastUpdate,
                       cm.DelFlag,
                       cm.CheckUpdate,
                       cm.IssueID,
                     };
      var Allcomment = await Comments.Where(td => td.IssueID == request.ID).OrderByDescending(x=>x.CreateAt).ToListAsync(cancellationToken);
      var tranfList = new List<CommentsDTO>();
      foreach(var item in Allcomment)
      {
        var tfitem = new CommentsDTO();
        tfitem.ID = item.ID;
        tfitem.IssueID = item.IssueID;
        tfitem.LastUpdate = item.LastUpdate;
        tfitem.UpdateBy = item.UpdateBy;
        tfitem.CheckUpdate = item.CheckUpdate;
        tfitem.Content = item.Content;
        tfitem.CreateAt = item.CreateAt;
        var GetCreateBy = ListUser.SingleOrDefault(x => x.ID == item.CreateBy);
        tfitem.CreateName = GetCreateBy.FullName;
        tfitem.PictureURL = GetCreateBy.PictureUrl;
        tfitem.CreateBy = item.CreateBy;
        tfitem.DelFlag = item.DelFlag;
        tranfList.Add(tfitem);
      }
      var model = new CommentsViewModel
      {
        Comments = _mapper.Map<IEnumerable<CommentsDTO>>(tranfList)
      };
      return model;
    }
  }
}
