using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Notifies.Queries.GetAll
{
  public class NotifyDTO
  {
    public int ID { get; set; }
    public long UserID { get; set; }
    public bool Status { get; set; }
    public int IssueID { get; set; }
  }
}
