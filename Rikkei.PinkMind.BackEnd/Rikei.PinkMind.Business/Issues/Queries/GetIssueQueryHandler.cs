using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rikei.PinkMind.Business.Issues.Queries.GetAllIssues;

namespace Rikei.PinkMind.Business.Issues.Queries
{
  public class GetIssueQueryHandler : IRequestHandler<GetIssueQuery, IssuesDTO>
  {
    private readonly PinkMindContext _pmContext;
    public GetIssueQueryHandler(PinkMindContext pinkMindContext)
    {
      _pmContext = pinkMindContext;
    }
    public async Task<IssuesDTO> Handle(GetIssueQuery request, CancellationToken cancellationToken)
    {
      var user = from us in _pmContext.Users
                 select new
                 {
                   us.ID,
                   us.FullName,
                   us.PictureUrl
                 };
      var ListUser = _pmContext.Users.ToList();

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
      var item = await issue.SingleOrDefaultAsync(x => x.ID == request.ID);

      var modelIssue = new IssuesDTO();

      modelIssue.Key = item.ProjectID + "-" + item.ID;
      modelIssue.ID = item.ID;
      modelIssue.IssueTypeID = item.IssueTypeID;
      modelIssue.IssueTypeName = item.IssueTypeName;
      modelIssue.IssueTypeColor = item.IssueTypeColor;
      modelIssue.LastUpdate = item.LastUpdate;
      modelIssue.MilestoneID = item.MilestoneID;
      modelIssue.MilestonName = item.MileStonName;
      modelIssue.PriorityID = item.PriorityID;
      modelIssue.PriorityName = item.PriorityName;
      modelIssue.ProjectID = item.ProjectID;
      modelIssue.ResolutionID = item.ResolutionID;
      modelIssue.ResolutionName = item.PriorityName;
      modelIssue.StatusID = item.StatusID;
      modelIssue.StatusName = item.StatusName;
      modelIssue.Subject = item.Subject;
      modelIssue.UpdateBy = item.UpdateBy;
      var GetUpdateBy = ListUser.SingleOrDefault(x => x.ID == item.UpdateBy);
      modelIssue.UpdateByName = GetUpdateBy.FullName;
      modelIssue.UpdateByPicture = GetUpdateBy.PictureUrl;
      modelIssue.VersionID = item.VersionID;
      modelIssue.VersionName = item.VersionName;
      modelIssue.AssigneeUser = item.AssigneeUser;
      var GetAssignee = ListUser.SingleOrDefault(x => x.ID == item.AssigneeUser);
      if (GetAssignee != null)
      {
        modelIssue.AssigneeName = GetAssignee.FullName;
        modelIssue.AssigneePicture = GetAssignee.PictureUrl;
      }
      modelIssue.CategoryID = item.CategoryID;
      modelIssue.CategoryName = item.CategoryName;
      modelIssue.CheckUpdate = item.CheckUpdate;
      modelIssue.CreateAt = item.CreateAt;
      modelIssue.CategoryName = item.CategoryName;
      modelIssue.CreateBy = item.CreateBy;
      var GetCreateBy = ListUser.SingleOrDefault(x => x.ID == item.CreateBy);
      modelIssue.CreateByName = GetUpdateBy.FullName;
      modelIssue.CreateByPicture = GetUpdateBy.PictureUrl;
      modelIssue.DelFlag = item.DelFlag;
      modelIssue.Description = item.Description;
      modelIssue.DueDate = item.DueDate;
      return modelIssue;
    }
  }
}
