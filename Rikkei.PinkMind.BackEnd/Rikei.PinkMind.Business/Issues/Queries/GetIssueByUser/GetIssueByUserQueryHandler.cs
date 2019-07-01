using AutoMapper;
using MediatR;
using Rikei.PinkMind.Business.Issues.Queries.GetAllIssues;
using Rikkei.PinkMind.DAO.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace Rikei.PinkMind.Business.Issues.Queries.GetIssueByUser
{
  public class GetIssueByUserQueryHandler : IRequestHandler<GetIssueByUserQuery, IssuesViewModel>
  {
    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;
    private readonly ClaimsPrincipal _caller;
    public GetIssueByUserQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }
    public async Task<IssuesViewModel> Handle(GetIssueByUserQuery request, CancellationToken cancellationToken)
    {
      var user = from us in _pmContext.Users
                 select new
                 {
                   us.ID,
                   us.FullName,
                   us.PictureUrl
                 };
      var ListUser =  _pmContext.Users.ToList();

      var issue = from iss in _pmContext.Issues
                  select new
                  {
                    iss.ID,
                    iss.IssueTypeID,
                    IssueTypeName = iss.IssueType.Name,
                    IssueTypeColor = iss.IssueType.BackgroundColor,
                    iss.Subject,
                    iss.Description,
                    iss.StatusID,
                    StatusName = iss.Status.Name,
                    iss.AssigneeUser,
                    AssigneName = "",
                    iss.PriorityID,
                    PriorityName = iss.Priority.Name,
                    iss.CategoryID,
                    CategoryName = iss.Category.Name,
                    iss.MilestoneID,
                    MileStonName = iss.Milestone.Name,
                    iss.VersionID,
                    VersionName = iss.Version.Name,
                    iss.ResolutionID,
                    ResolutionName = iss.Resolution.Name,
                    iss.DueDate,
                    iss.ProjectID,
                    CreateByName = "",
                    iss.CreateAt,
                    iss.CreateBy,
                    iss.UpdateBy,
                    UpdateByName = "",
                    iss.LastUpdate,
                    iss.DelFlag,
                    iss.CheckUpdate,
                  };
      var List = await issue.ToListAsync(cancellationToken);

      if (request.Key == "Created")
      {
        List = await issue.Where(x => x.CreateBy == request.ID).ToListAsync(cancellationToken);
      }

      else if (request.Key == "Assigned")
      {
        List = await issue.Where(x => x.AssigneeUser == request.ID).ToListAsync(cancellationToken);
      }
      var modelIssue = new List<IssuesDTO>();
      foreach (var item in List)
      {
        var tfItem = new IssuesDTO();
        tfItem.Key = item.ProjectID + "-" + item.ID;
        tfItem.ID = item.ID;
        tfItem.IssueTypeID = item.IssueTypeID;
        tfItem.IssueTypeName = item.IssueTypeName;
        tfItem.IssueTypeColor = item.IssueTypeColor;
        tfItem.LastUpdate = item.LastUpdate;
        tfItem.MilestoneID = item.MilestoneID;
        tfItem.MilestonName = item.MileStonName;
        tfItem.PriorityID = item.PriorityID;
        tfItem.PriorityName = item.PriorityName;
        tfItem.ProjectID = item.ProjectID;
        tfItem.ResolutionID = item.ResolutionID;
        tfItem.ResolutionName = item.PriorityName;
        tfItem.StatusID = item.StatusID;
        tfItem.StatusName = item.StatusName;
        tfItem.Subject = item.Subject;
        tfItem.UpdateBy = item.UpdateBy;
        var GetUpdateBy = ListUser.SingleOrDefault(x => x.ID == tfItem.UpdateBy);
        tfItem.UpdateByName = GetUpdateBy.FullName;
        tfItem.UpdateByPicture = GetUpdateBy.PictureUrl;
        tfItem.VersionID = item.VersionID;
        tfItem.VersionName = item.VersionName;
        tfItem.AssigneeUser = item.AssigneeUser;
        //var GetAssignee = ListUser.Where(x => x.ID == tfItem.AssigneeUser).First();
        tfItem.AssigneeName = "Admin";
        tfItem.AssigneePicture = "Admin";
        tfItem.CategoryID = item.CategoryID;
        tfItem.CategoryName = item.CategoryName;
        tfItem.CheckUpdate = item.CheckUpdate;
        tfItem.CreateAt = item.CreateAt;
        tfItem.CategoryName = item.CategoryName;
        tfItem.CreateBy = item.CreateBy;
        var GetCreateBy = ListUser.SingleOrDefault(x => x.ID == tfItem.CreateBy);
        tfItem.CreateByName = GetUpdateBy.FullName;
        tfItem.CreateByPicture = GetUpdateBy.PictureUrl;
        tfItem.DelFlag = item.DelFlag;
        tfItem.Description = item.Description;
        tfItem.DueDate = item.DueDate;
        modelIssue.Add(tfItem);
      }

      var model = new IssuesViewModel
      {
        Issues = _mapper.Map<IEnumerable<IssuesDTO>>(modelIssue)
      };

      return model;
    }
  }
}
