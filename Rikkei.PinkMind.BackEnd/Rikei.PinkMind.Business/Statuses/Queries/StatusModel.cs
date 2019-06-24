using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Rikkei.PindMind.DAO.Models;

namespace Rikei.PinkMind.Business.Statuses.Queries
{
    public class StatusModel
    {
    public int ID { get; set; }
    public string Name { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public static Expression<Func<Status, StatusModel>> Projection
    {
      get
      {
        return status => new StatusModel
        {
          ID = status.ID,
          Name = status.Name,
          CreateAt = status.CreateAt,
          CreateBy = status.CreateBy,
          UpdateBy = status.UpdateBy,
          LastUpdate = status.LastUpdate,
          DelFlag = status.DelFlag
        };
      }
    }
    public static StatusModel Create(Status status)
    {
      return Projection.Compile().Invoke(status);
    }
  }
}
