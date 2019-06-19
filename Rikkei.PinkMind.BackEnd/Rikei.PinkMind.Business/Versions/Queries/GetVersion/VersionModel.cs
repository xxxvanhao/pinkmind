using Rikkei.PindMind.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Rikei.PinkMind.Business.Versions.Queries.GetVersion
{
  public class VersionModel
  {
    public long ID { get; set; }
    public string Name { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public string CheckUpdate { get; set; }

    public static Expression<Func<Rikkei.PindMind.DAO.Models.Version, VersionModel>> Projection
    {
      get
      {
        return version => new VersionModel
        {
          ID = version.ID,
          Name = version.Name,
          CreateAt = version.CreateAt,
          CreateBy = version.CreateBy,
          LastUpdate = version.LastUpdate,
          UpdateBy = version.UpdateBy,
          CheckUpdate = version.CheckUpdate,
          DelFlag = version.DelFlag
        };
      }
    }
    public static VersionModel Create (Rikkei.PindMind.DAO.Models.Version version)
    {
      return Projection.Compile().Invoke(version);
    }
  }
}
