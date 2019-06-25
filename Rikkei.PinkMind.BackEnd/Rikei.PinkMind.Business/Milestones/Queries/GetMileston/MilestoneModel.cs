using Rikkei.PindMind.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Rikei.PinkMind.Business.Milestones.Queries.GetMileston
{
  public class MilestonModel
  {
    public long ID { get; set; }
    public string Name { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public byte[] CheckUpdate { get; set; }

    public static Expression<Func<Milestone, MilestonModel>> Projection
    {
      get
      {
        return milestone => new MilestonModel
        {
          ID = milestone.ID,
          Name = milestone.Name,
          CreateAt = milestone.CreateAt,
          CreateBy = milestone.CreateBy,
          LastUpdate = milestone.LastUpdate,
          UpdateBy = milestone.UpdateBy,
          CheckUpdate = milestone.CheckUpdate,
          DelFlag = milestone.DelFlag
        };
      }
    }
    public static MilestonModel Create(Milestone milestone)
    {
      return Projection.Compile().Invoke(milestone);
    }
  }
}