using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Resolutions.Queries.GetAllResolution
{
  public class ResolutionViewModel
  {
    public IEnumerable<ResolutionDTO> resolutions { get; set; }
  }
}
