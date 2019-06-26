using Rikkei.PindMind.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Text;

namespace Rikei.PinkMind.Business.Issues.Queries
{
  public class IssueModel
  {
    public int ID { get; set; }
    public int IssueTypeID { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public int StatusID { get; set; }
    public long? AssigneeUser { get; set; }
    public int? PriorityID { get; set; }
    public int? CategoryID { get; set; }
    public int? MilestoneID { get; set; }
    public int? VersionID { get; set; }
    public int? ResolutionID { get; set; }
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
          Subject = issue.Subject,
          Description = WebUtility.HtmlDecode(issue.Description),
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
          CreateAt =issue.CreateAt,
          UpdateBy = issue.UpdateBy,
          LastUpdate = issue.LastUpdate,
          DelFlag = issue.DelFlag
        };
      }
    }
    public static IssueModel Create(Issue issue)
    {
      return Projection.Compile().Invoke(issue);
    }
  }
}
