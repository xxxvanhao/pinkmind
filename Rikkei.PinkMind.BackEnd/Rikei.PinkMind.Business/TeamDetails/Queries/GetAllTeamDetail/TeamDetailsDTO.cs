using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.TeamDetails.Queries.GetAllTeamDetail
{
  public class TeamDetailsDTO
  {
    public int ID { get; set; }
    public long UserID { get; set; }
    public int TeamID { get; set; }
    public int RoleID { get; set; }
    public DateTime JoinedOn { get; set; }
    public long? AddBy { get; set; }
    public bool DelFlag { get; set; }
  }
}
