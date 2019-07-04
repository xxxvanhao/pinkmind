using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rikei.PinkMind.Business.Notifies.Queries.GetAll
{
  public class NotifyDTO
  {
    public int ID { get; set; }
    public bool Status { get; set; }
    public int IssueID { get; set; }
    public string AvatarPath { get; set; }
    public string UserName { get; set; }
    public string ActionName { get; set; }
    public string IssueKey { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    [DataType(DataType.Date)]
    public DateTime UpdateTime { get; set; }
    public string SpaceID { get; set; }
    public string ProjectKey { get; set; }
  }
}
