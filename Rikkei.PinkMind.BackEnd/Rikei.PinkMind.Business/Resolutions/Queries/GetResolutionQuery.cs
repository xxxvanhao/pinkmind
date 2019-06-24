using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Resolutions.Queries
{
  public class GetResolutionQuery : IRequest<ResolutionModel>
  {
    public int ID { get; set; }
  }
}
