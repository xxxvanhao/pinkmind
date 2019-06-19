using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Versions.Queries.GetVersion
{
  public class GetVersionQuery : IRequest<VersionModel>
  {
    public long ID { get; set; }
  }
}
