using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Rikkei.PindMind.DAO.Models;

namespace Rikei.PinkMind.Business.TeamDetails.Queries.GetTeamDetail
{
  class TeamDetailModel
  {
    public long ID { get; set; }
    public long UserID { get; set; }
    public long TeamID { get; set; }
    public long RoleID { get; set; }
    public DateTime JoinedOn { get; set; }
    public long AddBy { get; set; }
    public bool DelFlag { get; set; }


    
    public static Expression<Func<TeamDetail, TeamDetailModel>> Projection
    {
      get
      {
        return teamDetail => new TeamDetailModel
        {
          ID = teamDetail.ID,
          RoleID = teamDetail.RoleID,
          TeamID = teamDetail.TeamID,
          UserID = teamDetail.UserID,
          JoinedOn = teamDetail.JoinedOn,
          AddBy = teamDetail.AddBy,
          DelFlag = teamDetail.DelFlag
        };
      }
    }
    public static TeamDetailModel Create(TeamDetail teamDetail)
    {
      return Projection.Compile().Invoke(teamDetail);
    }
  }
}
