using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.SpaceControls.Queries.GetpmSpaceControl
{
  public class GetpmSpaceControlQuery : IRequest<SpaceControlModel>
  {
    public long userId { get; set; }
  }
}
