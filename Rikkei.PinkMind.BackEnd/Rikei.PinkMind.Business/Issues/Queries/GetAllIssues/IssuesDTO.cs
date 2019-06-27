using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Issues.Queries.GetAllIssues
{
  public class IssuesDTO
  {
    public int ID { get; set; }
    public string Key { get; set; }
    public int IssueTypeID { get; set; }
    public string IssueTypeName { get; set; }
    public string IssueTypeColor { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public int StatusID { get; set; }
    public string StatusName { get; set; }
    public long? AssigneeUser { get; set; }
    public string AssigneeName { get; set; }
    public string AssigneePicture { get; set; }
    public int? PriorityID { get; set; }
    public string PriorityName { get; set; }
    public int? CategoryID { get; set; }
    public string CategoryName { get; set; }
    public int? MilestoneID { get; set; }
    public string MilestonName { get; set; }
    public int? VersionID { get; set; }
    public string VersionName { get; set; }
    public int? ResolutionID { get; set; }
    public string ResolutionName { get; set; }
    public DateTime DueDate { get; set; }
    public string ProjectID { get; set; }
    public long CreateBy { get; set; }
    public string CreateByName { get; set; }
    public string CreateByPicture { get; set; }
    public string RegisterName { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public string UpdateByName { get; set; }
    public string UpdateByPicture { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public byte[] CheckUpdate { get; set; }
  }
}
