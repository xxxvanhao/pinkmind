using Rikkei.PindMind.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.SpaceControls.Queries.GetpmSpaceControl
{
  public class SpaceControlModel
  {
    public long ID { get; set; }
    public string SpaceID { get; set; }
    public long ControlBy { get; set; }
    public static Expression<Func<SpaceControl, SpaceControlModel>> Projection
    {
      get
      {
        return pmSpaceControl => new SpaceControlModel
        {
          ID = pmSpaceControl.ID,
          SpaceID = pmSpaceControl.SpaceID,
          ControlBy = pmSpaceControl.ControlBy
          
        };
      }
    }

    public static SpaceControlModel Create(SpaceControl entity)
    {
      return Projection.Compile().Invoke(entity);
    }
  }
}
