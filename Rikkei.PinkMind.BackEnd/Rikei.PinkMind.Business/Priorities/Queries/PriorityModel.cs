using Rikkei.PindMind.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Rikei.PinkMind.Business.Priorities.Queries
{
  public class PriorityViewModel
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public byte[] CheckUpdate { get; set; }
    public static Expression<Func<Priority, PriorityViewModel>> Projection
    {
      get
      {
        return priority => new PriorityViewModel
        {
          ID = priority.ID,
          CreateAt = priority.CreateAt,
          CreateBy = priority.CreateBy,
          Name = priority.Name,
          UpdateBy = priority.UpdateBy,
          LastUpdate = priority.LastUpdate,
          DelFlag = priority.DelFlag,
          CheckUpdate = priority.CheckUpdate
        };
      }
    }
    public static PriorityViewModel Create(Priority priority)
    {
      return Projection.Compile().Invoke(priority);
    }
  }
}