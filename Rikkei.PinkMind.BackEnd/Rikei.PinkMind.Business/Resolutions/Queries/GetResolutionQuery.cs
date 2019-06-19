using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Resolutions.Queries
{
    class GetResolutionQuery : IRequest<ResolutionModel>
  {
    public long ID { get; set; }
  }
}
