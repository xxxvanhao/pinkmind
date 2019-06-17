using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.pmSpaces.Queries.GetpmSpace
{
  class GetpmSpaceQuery : IRequest<SpaceModel>
  {
    public int SpaceID { get; set; }

  }
}
