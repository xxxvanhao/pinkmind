using Rikkei.PindMind.DAO.Models;
using System;
using System.Linq.Expressions;

namespace Rikei.PinkMind.Business.IssueTypes.Queries
{
  public class IssueTypeModel
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public string BackgroundColor { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public string CheckUpdate { get; set; }
    public static Expression<Func<IssueType, IssueTypeModel>> Projection
    {
      get
      {
        return issueType => new IssueTypeModel
        {
          ID = issueType.ID,
          Name = issueType.Name,
          BackgroundColor = issueType.BackgroundColor,
          UpdateBy = issueType.UpdateBy,
          CreateAt = issueType.CreateAt,
          DelFlag = issueType.DelFlag,
          CheckUpdate = issueType.CheckUpdate,
        };
      }
    }
    public static IssueTypeModel Create(IssueType issueType)
    {
      return Projection.Compile().Invoke(issueType);
    }
  }
}
