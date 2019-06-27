using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Versions.Queries.GetAllVersions
{
  public class GetAllVersionQuery : IRequest<VersionViewModel>
  {
  }
}
