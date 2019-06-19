using Rikkei.PindMind.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Rikei.PinkMind.Business.Issues.Queries
{
  public class IssueModel
  {
    public long ID { get; set; }
    public long IssueTypeID { get; set; }
    public string IssueKey { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public long StatusID { get; set; }
    public long AssigneeUser { get; set; }
    public long PriorityID { get; set; }
    public long CategoryID { get; set; }
    public long MilestoneID { get; set; }
    public long VersionID { get; set; }
    public long? ResolutionID { get; set; }
    public DateTime DueDate { get; set; }
    public string ProjectID { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public string CheckUpdate { get; set; }
    public static Expression<Func<Issue, IssueModel>> Projection
    {
      get
      {
        return issue => new IssueModel
        {
          ID = issue.ID,
          IssueTypeID = issue.IssueTypeID,
          IssueKey = issue.IssueKey,
          Subject = issue.Subject,
          Description = issue.Description,
          StatusID = issue.StatusID,
          AssigneeUser = issue.AssigneeUser,
          PriorityID = issue.PriorityID,
          CategoryID = issue.CategoryID,
          MilestoneID = issue.MilestoneID,
          VersionID = issue.VersionID,
          ResolutionID = issue.ResolutionID,
          DueDate = issue.DueDate,
          ProjectID = issue.ProjectID,
          CreateBy = issue.CreateBy,
          CreateAt = DateTime.UtcNow,
          UpdateBy = issue.UpdateBy,
          LastUpdate = DateTime.UtcNow,
          DelFlag = true,
        };
      }
    }
    public static IssueModel Create(Issue issue)
    {
      return Projection.Compile().Invoke(issue);
    }
  }
}
