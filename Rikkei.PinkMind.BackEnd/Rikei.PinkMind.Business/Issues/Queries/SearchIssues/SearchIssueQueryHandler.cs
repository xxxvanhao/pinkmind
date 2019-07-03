using AutoMapper;
using MediatR;
using Rikei.PinkMind.Business.Issues.Queries.GetAllIssues;
using Rikkei.PinkMind.DAO.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Rikei.PinkMind.Business.Issues.Queries.SearchIssues
{
  public class SearchIssueQueryHandler : IRequestHandler<SearchIssueQuery, IssuesViewModel>
  {
    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;
    public SearchIssueQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }
    public async Task<IssuesViewModel> Handle(SearchIssueQuery request, CancellationToken cancellationToken)
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
      var List = await issue.Where(x=>x.ProjectID.Equals(request.ProjectID)).ToListAsync(cancellationToken);
      if(request.Key != null)
      {
        List = List.Where(x => x.Subject.Contains(request.Key)).ToList();
      }
      if(request.AssigneeUser != 0)
      {
        List = List.Where(x => x.AssigneeUser.Equals(request.AssigneeUser)).ToList();
      }
      if (request.CategoryID != 0)
      {
        List = List.Where(x => x.CategoryID.Equals(request.CategoryID)).ToList();
      }
      if (request.MilestoneID != 0)
      {
        List = List.Where(x => x.MilestoneID.Equals(request.MilestoneID)).ToList();
      }
      if (request.StatusID != 0)
      {
        List = List.Where(x => x.StatusID.Equals(request.StatusID)).ToList();
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
        var GetUpdateBy = ListUser.SingleOrDefault(x => x.ID == item.UpdateBy);
        tfItem.UpdateByName = GetUpdateBy.FullName;
        tfItem.UpdateByPicture = GetUpdateBy.PictureUrl;
        tfItem.VersionID = item.VersionID;
        tfItem.VersionName = item.VersionName;
        tfItem.AssigneeUser = item.AssigneeUser;
        var GetAssignee = ListUser.SingleOrDefault(x => x.ID == item.AssigneeUser);
        if(GetAssignee != null)
        {
          tfItem.AssigneeName = GetAssignee.FullName;
          tfItem.AssigneePicture = GetAssignee.PictureUrl;
        }
        tfItem.CategoryID = item.CategoryID;
        tfItem.CategoryName = item.CategoryName;
        tfItem.CheckUpdate = item.CheckUpdate;
        tfItem.CreateAt = item.CreateAt;
        tfItem.CategoryName = item.CategoryName;
        tfItem.CreateBy = item.CreateBy;
        var GetCreateBy = ListUser.SingleOrDefault(x => x.ID == item.CreateBy);
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
