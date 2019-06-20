using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.pmSpaces.Queries.GetpmSpace
{
  public class GetpmSpaceQuery : IRequest<SpaceModel>
  {
    public string SpaceID { get; set; }

  }
}
