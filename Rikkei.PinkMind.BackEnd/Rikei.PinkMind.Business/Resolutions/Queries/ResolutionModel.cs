using Rikkei.PindMind.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Rikei.PinkMind.Business.Resolutions.Queries
{
    class ResolutionModel
    {
    public long ID { get; set; }
    public string Name { get; set; }
    public DateTime CreateAt { get; set; }
    public long CreateBy { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public byte[] CheckUpdate { get; set; }
    public static Expression<Func<Resolution, ResolutionModel>> Projection
    {
      get
      {
        return resolution => new ResolutionModel
        {
          ID = resolution.ID,
          Name = resolution.Name,
          CreateAt = resolution.CreateAt,
          CreateBy = resolution.CreateBy,
          UpdateBy = resolution.UpdateBy,
          LastUpdate = resolution.LastUpdate,
          CheckUpdate = resolution.CheckUpdate,
          DelFlag  = resolution.DelFlag
        };
      }
    }
    public static ResolutionModel Create(Resolution resolution)
    {
      return Projection.Compile().Invoke(resolution);
    }
  }
}
