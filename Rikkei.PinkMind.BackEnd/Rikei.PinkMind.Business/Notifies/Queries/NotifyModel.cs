using Rikkei.PindMind.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Rikei.PinkMind.Business.Notifies.Queries
{
    public class NotifyModel
    {
    public long ID { get; set; }
    public long UserID { get; set; }
    public bool Status { get; set; }
    public long IssueID { get; set; }
    public static Expression<Func<Notify, NotifyModel>> Projection
    {
      get
      {
        return notify => new NotifyModel
        {
          ID = notify.ID,
          IssueID = notify.IssueID,
          UserID = notify.UserID,
          Status = notify.Status
        };
      }
    }
    public static NotifyModel Create(Notify notify)
    {
      return Projection.Compile().Invoke(notify);
    }
  }
}
