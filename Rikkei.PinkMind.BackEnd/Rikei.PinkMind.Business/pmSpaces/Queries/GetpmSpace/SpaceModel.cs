using Rikkei.PindMind.DAO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.pmSpaces.Queries.GetpmSpace
{
  public class SpaceModel
  {
    public string SpaceID { get; set; }
    public string OrganizationName { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    [Timestamp]
    public byte[] CheckUpdate { get; set; }
    public static Expression<Func<Space, SpaceModel>> Projection
    {
      get
      {
        return pmSpace => new SpaceModel
        {
          SpaceID = pmSpace.SpaceID,
          OrganizationName = pmSpace.OrganizationName,
          CreateBy = pmSpace.CreateBy,
          CreateAt = pmSpace.CreateAt,
          UpdateBy = pmSpace.UpdateBy,
          LastUpdate = pmSpace.LastUpdate,
          DelFlag = pmSpace.DelFlag,
          CheckUpdate = pmSpace.CheckUpdate
        };
      }
    }

    public static SpaceModel Create(Space entity)
    {
      return Projection.Compile().Invoke(entity);
    }
  }
}
