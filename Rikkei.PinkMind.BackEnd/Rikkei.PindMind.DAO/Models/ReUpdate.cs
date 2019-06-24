using System;
using System.Collections.Generic;
using System.Text;

namespace Rikkei.PindMind.DAO.Models
{
  public class ReUpdateSpace
  {
    public int ID { get; set; }
    public string AvatarPath { get; set; }
    public string UserName { get; set; }
    public string ActionName { get; set; }
    public string IssueKey { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public DateTime UpdateTime { get; set; }
    public string SpaceID { get; set; }
    public string ProjectKey { get; set; }
  }
}
