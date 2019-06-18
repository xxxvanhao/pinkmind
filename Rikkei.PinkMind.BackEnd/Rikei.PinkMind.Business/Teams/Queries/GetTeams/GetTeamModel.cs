using Rikei.PinkMind.Business.SpaceControls.Queries.GetpmSpaceControl;
using Rikkei.PindMind.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Rikei.PinkMind.Business.Teams.Queries.GetTeams
{
  public class GetTeamModel
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public string CheckUpdate { get; set; }

    public static Expression<Func<Team, GetTeamModel>> Projection
    {
      get
      {
        return team => new GetTeamModel
        {
          ID = team.ID,
          Name = team.Name,
          CreateAt = team.CreateAt,
          CreateBy = team.CreateBy,
          CheckUpdate = team.CheckUpdate,
          LastUpdate = team.LastUpdate,
          DelFlag = team.DelFlag,
          UpdateBy = team.UpdateBy
        };
      }
    }
    public static GetTeamModel Create(Team team)
    {
      return Projection.Compile().Invoke(team);
    }
  }
}

